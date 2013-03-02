using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BaseContextInitializer :DropCreateDatabaseAlways<BaseContext>
    {
        protected override void Seed(BaseContext context)
        {
            base.Seed(context);
            
            #region Components
            Component MotherBoard = new Component
            {
                Description = "Motherboard",
                Price = 80M,
                Stock = 40
            };

            Component Memory = new Component
            {
                Description = "8Gb",
                Price = 30M,
                Stock = 400
            };

            Component HardDisk = new Component
            {
                Description = "Motherboard",
                Price = 80M,
                Stock = 40
            };
            Component Processor = new Component
            {
                Description = "Processor",
                Price = 100M,
                Stock = 80
            };

            
#endregion

            #region Workers
            var Sammy = new Worker
            {
                Name="Sammy"
            };
            var Sonny = new Worker
            {
                Name = "Sonny"
            };
            var Suzzy = new Worker
            {
                Name = "Suzzy"
            };
            #endregion

            #region Accounts
            new List<Account>
            {
               new Account
               {
                Company = "NorthernLighting",
                Address = new Address{HouseNumber = 2, PostCode="PA34RD", StreetName="Stoneway Drive" },
                Contact = new Contact{FirstName="Johnan", LastName="Botha", Email="J@Hotmail.com", PhoneNo = "01418864534"},
                Repairs = new List<Repair>
                {
                     new Repair
                    {
                        Completed = false,
                        Team = new List<Worker>{Sammy}, 
                        CreatedAt = DateTime.Now
                    }, new Repair
                    {
                        Completed = true,
                        Team = new List<Worker>{Sammy,Suzzy,Sonny}, 
                        PartsUsed = new List<RepairPart>
                        {
                            new RepairPart{Component = MotherBoard, Quantity = 1},
                            new RepairPart{Component = Processor, Quantity = 1},
                            new RepairPart{Component = Memory, Quantity = 3}
                        },
                        CreatedAt = DateTime.Now,
                        HoursOfLabour = 5
                    }, new Repair
                    {
                        Completed = true,
                        Team = new List<Worker>{Sonny}, 
                        PartsUsed = new List<RepairPart>
                        {
                            new RepairPart{Component = HardDisk, Quantity = 2},
                        },
                        CreatedAt = DateTime.Now,
                        HoursOfLabour = 3
                    }
                }
               },
                new Account
               {
                Company = "SmarterLending",
                Address = new Address{HouseNumber = 3, PostCode="GR34RD", StreetName="Langway Square" },
                Contact = new Contact{FirstName="Bobby", LastName="Johnson", Email="B@Hotmail.com", PhoneNo = "01518674538"},
                Repairs = new List<Repair>
                {
                    new Repair
                    {
                        Completed = false,
                        Team = new List<Worker>{Sammy,Sonny}, 
                        CreatedAt = DateTime.Now
                    }, new Repair
                    {
                        Completed = true,
                        Team = new List<Worker>{Suzzy}, 
                        PartsUsed = new List<RepairPart>
                        {
                            new RepairPart{Component = MotherBoard, Quantity = 1},
                            new RepairPart{Component = Memory, Quantity = 2},
                        },
                        CreatedAt = DateTime.Now,
                        HoursOfLabour = 2
                    }, new Repair
                    {
                        Completed = true,
                        Team = new List<Worker>{Sonny,Sammy}, 
                        PartsUsed = new List<RepairPart>
                        {
                            new RepairPart{Component = MotherBoard, Quantity = 1},
                            new RepairPart{Component = HardDisk, Quantity = 1},
                            new RepairPart{Component = Memory, Quantity = 4},
                        },
                        CreatedAt = DateTime.Now,
                        HoursOfLabour = 4
                    }
                }
               }
            }.ForEach(accs => 
            {
                accs.Repairs.ForEach(r => r.ProcessRepair());
                context.Accounts.Add(accs); 
            });
            #endregion

            context.SaveChanges();
        }
    }
}
