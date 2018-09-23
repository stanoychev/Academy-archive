using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sensei.ViewModels
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