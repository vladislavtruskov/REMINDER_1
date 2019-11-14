using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder
{
    [Serializable]
    [Flags]
    public enum Days
    {
        Monday = 1,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday
    };
    [Serializable]
    public class Remind
    {
        // заголовок напоминания
        public string Title { get; set; }

        // описание напоминания
        public string Discription { get; set; }

        // Дата напоминания
        public DateTime Date { get; set; }

        // флаг указывающий, будет ли напоминания оповещать каждый день
        public bool EveryDay { get; set; }

        // по каким дням будет напоминание
        public Days TimeTable { get; set; }
        public Remind()
        {
            Title = "Title";
            Discription = "Discription";
            Date = DateTime.Now;
            EveryDay = false;
            TimeTable = 0;
        }
        public Remind(string title, string discription, DateTime date, bool everyday)
        {
            Title = title;
            Discription = discription;
            Date = date;
            EveryDay = everyday;
            TimeTable = 0;
        }
    }
}
