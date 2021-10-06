using System;
using System.Drawing;

namespace FacebookLogics.Birthday_Feature
{
    public class Charm
    {
        public enum eCharm
        {
            Capricorn = 1,
            Aquarius,
            Pisces,
            Libra,
            Scorpio,
            Sagittarius,
            Cancer,
            Leo,
            Virgo,
            Aries,
            Taurus,
            Gemini
        }

        private readonly int r_StartingDay;
        private readonly int r_EndingDay;
        private readonly int r_Month;
        private readonly eCharm r_Charm;
        private readonly string r_FortuneString;
        private readonly Bitmap r_GemImage;

        public eCharm Gem
        {
            get
            {
                return r_Charm;
            }
        }

        public int Month
        {
            get
            {
                return r_Month;
            }
        }

        public int StartingDay
        {
            get
            {
                return r_StartingDay;
            }
        }

        public int EndingDay
        {
            get
            {
                return r_EndingDay;
            }
        }

        public String Fortune
        {
            get
            {
                return r_FortuneString;
            }
        }

        public Bitmap FortuneGem
        {
            get
            {
                return r_GemImage;
            }
        }

        public Charm(int i_StartingDay, int i_EndingDay, int i_Month, eCharm i_Charm, string i_FortuneTextFileName
                     , Bitmap i_FortuneImageFileName)
        {
            r_StartingDay = i_StartingDay;
            r_EndingDay = i_EndingDay;
            r_Month = i_Month;
            r_Charm = i_Charm;
            r_FortuneString = i_FortuneTextFileName;
            r_GemImage = i_FortuneImageFileName;
        }
    }
}