using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarImport
{
    public class YearType
    {

        public static int getDayCount(int _year, int _month)
        {
            int dayCount = 30;
            switch (_month)
            {
                case 2:
                    {
                        if (_year % 100 == 0)
                        {
                            if (_year % 400 == 0)
                            {
                                dayCount = 29;
                                return dayCount;
                            }
                            else
                            {
                                dayCount = 28;
                                return dayCount;
                            }
                        }
                        else if (_year % 4 == 0)
                        {
                            dayCount = 29;
                            return dayCount;
                        }
                        dayCount = 28;
                        break;
                    }
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    dayCount = 31;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    dayCount = 30;
                    break;
            }

            return dayCount;
        }

        public static bool isYear(int _year)
        {
            if (_year % 100 == 0)
            {
                if (_year % 400 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (_year % 4 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
