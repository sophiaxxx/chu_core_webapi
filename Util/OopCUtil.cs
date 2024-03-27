using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chu_core_webapi.Util
{
    public class OopCUtil
    {
        public void DateToDay()
        {
            Console.WriteLine("請輸入年月日");
            int y = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int d = Convert.ToInt32(Console.ReadLine());
            int total = 365; //平年
            if ((y % 4 == 0 && y % 100 != 0) || y % 400 == 0)
                total = 366;
            switch (m)
            {
                case 1:
                    total -= 31;
                    goto case 2;
                case 2:
                    if ((y % 4 == 0 && y % 100 != 0) || y % 400 == 0) //閏年
                    {
                        total -= 29;
                    }
                    else
                    {
                        total -= 28;
                    }
                    goto case 3;
                case 3:
                    total -= 31;
                    goto case 4;
                case 4:
                    total -= 30;
                    goto case 5;
                case 5:
                    total -= 31;
                    goto case 6;
                case 6:
                    total -= 30;
                    goto case 7;
                case 7:
                    total -= 31;
                    goto case 8;
                case 8:
                    total -= 31;
                    goto case 9;
                case 9:
                    total -= 30;
                    goto case 10;
                case 10:
                    total -= 31;
                    goto case 11;
                case 11:
                    total -= 30;
                    goto case 12;
                case 12:
                    total -= 31;
                    goto default;
                default: total += d; break;
            }
            Console.WriteLine(m + "月" + d + "日是" + y + "年的第" + total + "天");

            Console.ReadKey();
        }
    }
}
