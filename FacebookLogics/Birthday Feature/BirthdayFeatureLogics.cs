using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using FacebookLogics.Birthday_Feature;

namespace FacebookLogics
{
    public static class BirthdayFeatureLogics
    {
        private static string getMonthsUntilBirthdayMsg(int i_MonthsToBirthday)
        {
            StringBuilder monthsUntilBirthdayMsg = new StringBuilder();
            monthsUntilBirthdayMsg.AppendFormat("There are {0} more months until your birthday", i_MonthsToBirthday);
            return monthsUntilBirthdayMsg.ToString();
        }

        private static string getOneMonthToBirthdayMsg()
        {
            StringBuilder monthsUntilBirthdayMsg = new StringBuilder();
            monthsUntilBirthdayMsg.Append("One more month to your birthday! Woohoo!");
            return monthsUntilBirthdayMsg.ToString();
        }

        private static string getBirthdayMsg(string io_LoggedInUserName)
        {
            StringBuilder birthdayMsg = new StringBuilder();
            birthdayMsg.AppendFormat("Happy Birthday Month {0} ", io_LoggedInUserName);
            birthdayMsg.Append(" We wish you the very best!");
            return birthdayMsg.ToString();
        }

        private static int countMonthsUntilBirthday(string io_LoggedInUserBirthday)
        {
            int currentMonth = DateTime.Now.Month;
            int monthsUntilBirthday = 0;
            int userBirthdayMonth = GetBirthdayMonth(io_LoggedInUserBirthday);
            if(userBirthdayMonth == -1)
            {
                monthsUntilBirthday = -1;
            }
            else
            {
                if(currentMonth > userBirthdayMonth)
                {
                    userBirthdayMonth = userBirthdayMonth + 12;
                    monthsUntilBirthday = userBirthdayMonth - currentMonth;
                }
                else
                {
                    monthsUntilBirthday = userBirthdayMonth - currentMonth;
                }
            }

            return monthsUntilBirthday;
        }

        internal static int GetBirthdayMonth(string i_LoggedInUserBirthday)
        {
            int birthdayMonth;
            string userBirthday = i_LoggedInUserBirthday;
            if(userBirthday != null)
            {
                birthdayMonth = ((userBirthday[0] - '0') * 10) + (userBirthday[1] - '0');
            }
            else
            {
                birthdayMonth = -1;
            }

            return birthdayMonth;
        }

        public static string CreateBirthdayMsg(string i_LoggedInUserBirthday)
        {
            string result;
            int monthsUntilBirthday = countMonthsUntilBirthday(i_LoggedInUserBirthday);
            if(monthsUntilBirthday == 0)
            {
                result = getBirthdayMsg(i_LoggedInUserBirthday);
            }
            else if(monthsUntilBirthday == 1)
            {
                result = getOneMonthToBirthdayMsg();
            }
            else if(monthsUntilBirthday == -1)
            {
                result = "Unfortunately we couldn't get your birthday, we hope it is soon";
            }
            else
            {
                result = getMonthsUntilBirthdayMsg(monthsUntilBirthday);
            }

            return result;
        }

        internal static int GetBirthDay(string io_Birthdate)
        {
            int birthDay = ((io_Birthdate[3] - '0') * 10) + (io_Birthdate[4] - '0');
            return birthDay;
        }

    }
}