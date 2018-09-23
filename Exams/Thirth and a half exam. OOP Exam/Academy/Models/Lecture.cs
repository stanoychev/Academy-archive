using Academy.Models.Contracts;
using Academy.Models.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Lecture : ILecture
    {
        private string name;
        private DateTime date;
        private ITrainer trainer;
        private IList<ILectureResource> resources = new List<ILectureResource>();

        public Lecture(string name, string date, ITrainer trainer)
        {
            this.Name = name;
            try
            {
                this.Date = DateTime.ParseExact(date, "yyyy-MM-d", CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid DateTime format!");
            }
            this.Trainer = trainer;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.StringValidator(value,
                    GlobalConstants.MinLectureNameLength,
                    GlobalConstants.MaxLectureNameLength,
                    GlobalMessages.ValidLectureName());
                this.name = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
            
        public ITrainer Trainer
        {
            get
            {
                return this.trainer;
            }
            set
            {
                this.trainer = value;
            }
        }

        public IList<ILectureResource> Resources
        {
            get
            {
                return this.resources;
            }
            set
            {
                this.resources = value;
            }
        }

        public override string ToString()
        {
            return string.Format("  * Lecture:\n   - Name: {0}\n   - Date: {1}\n   - Trainer username: {2}\n   - Resources:\n{3}",
                this.name,
                this.date.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.CurrentCulture),
                this.Trainer.Username,
                Toolbox.PrintEnumerable(this.resources, GlobalConstants.NoResourcesResults));
        }

    }
}
