using System;

namespace Sensei.Models.View
{
    public class DateValueViewModel
    {
        public DateTime? year { get; set; }
        public string value { get; set; }

        public DateValueViewModel(DateTime? date, string value)
        {
            this.year = date;
            this.value = value;
        }
    }
}