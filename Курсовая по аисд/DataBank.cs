using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_по_аисд
{
    public static class DataBank
    {
        public static string StartTime;
        public static string EndTime;
        public static DateTime Date;
        public static string DopInformation;
        public static bool Event_is_Booked = false;
        public static List<string> StartTimeItems = new List<string>();

        public static string Login;
        //массив списков для хранения забронированных промежутков времени.
        //массив состоит из 14 дней, каждый день - это список границ забронированного промежутка
        public static List<int>[] BookedTime = new List<int>[14];

        public static Bron change_bron = new Bron();


    }
}
