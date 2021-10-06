using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookLogics.Birthday_Feature
{
    public class CharmArray
    {
        private readonly List<Charm> r_CharmList;

        public List<Charm> CharmList
        {
            get
            {
                return r_CharmList;
            }
        }

        public CharmArray()
        {
            r_CharmList = new List<Charm>(12);
            Charm capricorn = new Charm(22, 20, 12, Charm.eCharm.Capricorn, Resource1.gdi1, Resource1.gdi);
            r_CharmList.Add(capricorn);
            Charm aquarius = new Charm(21, 19, 1, Charm.eCharm.Aquarius, Resource1.dli1, Resource1.dli);
            r_CharmList.Add(aquarius);
            Charm pisces = new Charm(20, 20, 2, Charm.eCharm.Pisces, Resource1.dagim1, Resource1.dagim);
            r_CharmList.Add(pisces);
            Charm libra = new Charm(24, 23, 9, Charm.eCharm.Libra, Resource1.moznaim1, Resource1.moznaim);
            r_CharmList.Add(libra);
            Charm scorpio = new Charm(24, 22, 10, Charm.eCharm.Scorpio, Resource1.akrav1, Resource1.akrav);
            r_CharmList.Add(scorpio);
            Charm sagittarius = new Charm(23, 21, 11, Charm.eCharm.Sagittarius, Resource1.kashat1, Resource1.kashat);
            r_CharmList.Add(sagittarius);
            Charm cancer = new Charm(22, 22, 6, Charm.eCharm.Cancer, Resource1.sartan1, Resource1.sartan);
            r_CharmList.Add(cancer);
            Charm leo = new Charm(23, 28, 7, Charm.eCharm.Leo, Resource1.arye1, Resource1.arye);
            r_CharmList.Add(leo);
            Charm virgo = new Charm(23, 23, 8, Charm.eCharm.Virgo, Resource1.betula1, Resource1.betula);
            r_CharmList.Add(virgo);
            Charm aries = new Charm(21, 20, 4, Charm.eCharm.Aries, Resource1.tale1, Resource1.tale);
            r_CharmList.Add(aries);
            Charm taurus = new Charm(21, 21, 4, Charm.eCharm.Taurus, Resource1.shor1, Resource1.shor);
            r_CharmList.Add(taurus);
            Charm gemini = new Charm(22, 21, 5, Charm.eCharm.Gemini, Resource1.teomim1, Resource1.teomim);
            r_CharmList.Add(gemini);
        }

        public static Charm GetCharmFromBirthday(string i_Birthdate)
        {
            int birthMonth = BirthdayFeatureLogics.GetBirthdayMonth(i_Birthdate);
            int birthDay = BirthdayFeatureLogics.GetBirthDay(i_Birthdate);
            Charm userCharm = getCharm(birthMonth, birthDay);
            return userCharm;
        }


        private static Charm getCharm(int i_BirthMonth, int i_BirthDay)
        {
            Charm result = null;
            CharmArray charmArray = new CharmArray();
            List<Charm> charmList = charmArray.CharmList;
            foreach(Charm charm in charmList)
            {
                if(i_BirthMonth == charm.Month)
                {
                    if(i_BirthDay >= charm.StartingDay)
                    {
                        result = charm;
                    }
                }
                else if(i_BirthMonth == (charm.Month + 1) % 12)
                {
                    if(i_BirthDay <= charm.EndingDay)
                    {
                        result = charm;
                    }
                }
            }


            return result;
        }
    }
}