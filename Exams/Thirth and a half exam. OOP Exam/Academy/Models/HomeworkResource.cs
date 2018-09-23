using Academy.Models.Abstract;
using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Utils;
using System.Globalization;

namespace Academy.Models
{
    public class HomeworkResource : Resource, ILectureResource
    {
        private readonly string type;
        private DateTime dueDate;

        public HomeworkResource(DateTime dueDate, string name, string url) : base(name, url)
        {
            this.type = GlobalConstants.HomeworkResourceType;
            this.DueDate = dueDate;
        }

        public DateTime DueDate
        {
            get
            {
                return this.dueDate.AddDays(GlobalConstants.HomeworkTerm);
            }
            set
            {
                this.dueDate = value;
            }
        }

        public override string ResourceType()
        {
            return this.type;
        }

        public override string ToString()
        {
            return string.Format("{0}\n     - Due date: {1}",
                base.ToString(),
                this.DueDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.CurrentCulture));
        }
    }
}
