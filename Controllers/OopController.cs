using chu_core_webapi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml;

namespace chu_core_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OopController : ControllerBase
    {
        // GET api/oop/boxing
        [HttpGet]
        [Route("boxing")]
        public List<OppViewModel> Boxing()
        {
            //Boxing
            List<OppViewModel> opps = new List<OppViewModel>();
            string num = "123";
            Object numobj = num;

            opps.Add(new OppViewModel
            {
                Objtype = num.GetType().ToString(),
                Objvalue = num,
            });

            opps.Add(new OppViewModel
            {
                Objtype = numobj.GetType().ToString(),
                Objvalue = numobj.ToString(),
            });


            //UnBoxing
            Object iobj = 123;
            int inum = (int)iobj;
            Console.WriteLine(iobj);
            Console.WriteLine(inum);

            return opps;
        }

        // GET api/oop/fibonacci
        [HttpGet]
        [Route("fibonacci")]
        public string Fibonacci()
        {
            string result = "";
            result +="這是一個算費式數列的程式";
            for (int n = 0; n <= 20; n++)
            {
                result += String.Format(" {0}", F(n));
            }
            return result;
        }
        private int F(int n)
        {

            if ((n == 0) || (n == 1))
                return n;
            else
            {
                return F(n - 1) + F(n - 2);
            }
        }



        // GET api/oop/aggregate
        [HttpGet]
        [Route("aggregate")]
        public string AggregateFunc()
        {
            var numbers = new int[] { 1, 3, 9, 2 };
            var result = numbers.Aggregate((total, next) => total + next);
            return result.ToString();
        }

        [HttpGet]
        [Route("sumempsalary")]
        public string SumEmpSalary()
        {
            var employees = new List<Employee>
            {
                new Employee { Name = "Bob", Salary = 35000.00, Dependents = 0 },
                new Employee { Name = "Sherry", Salary = 75250.00, Dependents = 1 },
                new Employee { Name = "Kathy", Salary = 32000.50, Dependents = 0 },
                new Employee { Name = "Joe", Salary = 17500.00, Dependents = 2 },
            };

            var totalSalary = employees.Sum(delegate (Employee e) { return e.Salary; });

            return totalSalary.ToString();
        }

        public void JsonTemp()
        {
            string jsonstr = @"{'id':1, 'jobjs':[{'jcode':'B','jdesc':'B level'},{'jcode':'C','jdesc':'C level'}]}";
            JList list = JsonConvert.DeserializeObject<JList>(jsonstr);
            foreach(var data in list.Jobjs)
            {
                Console.WriteLine(data.Jcode);
                Console.WriteLine(data.Jdesc);
            }
        }

        public void JsonTemp2()
        {
            // 建立 JSON
            var avatar = new JsonObject
            {
                ["Id"] = "A001",
                ["Name"] = "Jeffrey",
                ["Extra"] = "Prop To Remove",
                ["Equipments"] = new JsonArray("Shield", "Sword", "Bottle")
            };
            // 動態指定屬性
            avatar["Score"] = 32767;
            // 加入物件屬性
            avatar["Pet"] = new JsonObject
            {
                ["Name"] = "Spot",
                ["Exp"] = 255
            };
            // 移除屬性
            avatar.Remove("Extra");
            // 對 JsonArray 進行操作
            var array = avatar["Equipments"]!.AsArray();
            array.Remove(array.Single(o => o?.GetValue<string>() == "Bottle"));
            array.Insert(0, "Bag");

            var json = avatar.ToJsonString(new JsonSerializerOptions
            {
                WriteIndented = true
            });
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(json);

            Console.ForegroundColor = ConsoleColor.Blue;
            // 由 JSON 還原回 JObject
            var restored = JsonNode.Parse(json)!.AsObject();
            // 列舉所有屬性
            foreach (var prop in restored)
            {
                var pn = prop.Key; var i = 0;
                // 測試屬性型別
                if (prop.Value is JsonObject)
                    Console.WriteLine($"{pn} is JsonObject");
                else if (prop.Value is JsonArray)
                    Console.WriteLine($"{pn} is JsonArray, length={prop.Value.AsArray().Count()}");
                // 使用 TryGetValue<T> 嘗試取值
                else if (prop.Value?.AsValue().TryGetValue<int>(out i) ?? false)
                    Console.WriteLine($"{pn} is int: {i}");
            }
            Console.ResetColor();
        }
    }

    class JObj
    {
        public string Jcode { get; set; }
        public string Jdesc { get; set; }
    }
    class JList
    {
        public string Id { get; set; }
        public List<JObj> Jobjs { get; set; }
    }
}
