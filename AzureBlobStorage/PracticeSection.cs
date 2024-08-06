using Azure.Core.Amqp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobStorage
{
    internal class PracticeSection
    {
        public static void DemoMethods()
        {
            var ann = new[]
            {
                new {
                    Id = 1,
                    Name = "Test1",
                    Subjects = new[] {
                                    new { SubId = "T1", SubName = "Eng"},
                                    new { SubId = "T2", SubName = "Comp"},
                                    }
                },
                  new {
                    Id = 2,
                    Name = "Test2",
                    Subjects = new[] {
                                    new { SubId = "T1", SubName = "Eng"},
                                    new { SubId = "T2", SubName = "Comp"},
                                    }
                },
                  new {
                    Id = 3,
                    Name = "Test3",
                    Subjects = new[] {
                                    new { SubId = "T1", SubName = "Eng"},
                                    new { SubId = "T2", SubName = "Comp"},
                                    }
                },
                  new {
                    Id = 4,
                    Name = "Test4",
                    Subjects = new[] {
                                    new { SubId = "T1", SubName = "Eng"},
                                    new { SubId = "T2", SubName = "Comp"},
                                    }
                },
                   new {
                    Id = 5,
                    Name = "Test5",
                    Subjects = new[] {
                                    new { SubId = "T1", SubName = "Eng"},
                                    new { SubId = "T2", SubName = "Comp"},
                                    }
                }
            };

            var annList = ann.ToList();
            //var annList1 = ann.Include(x=>x.Subjetcs).ToList();
        }
    }
}
