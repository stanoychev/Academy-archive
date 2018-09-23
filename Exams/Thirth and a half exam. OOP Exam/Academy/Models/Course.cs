using Academy.Models.Contracts;
using Academy.Models.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;

namespace Academy.Models
{
    public class Course : ICourse
    {
        private string name;
        private int lecturesPerWeek;
        private DateTime startingDate;
        private IList<IStudent> onsiteStudents = new List<IStudent>();
        private IList<IStudent> onlineStudents = new List<IStudent>();
        private IList<ILecture> lectures = new List<ILecture>();

        public Course(string name, string lecturesPerWeek, string startingDate)
        {
            this.Name = name;
            try
            {
                this.LecturesPerWeek = int.Parse(lecturesPerWeek);
            }
            catch (Exception)
            {
                throw new ArgumentException(GlobalMessages.LecturesPerWeeek());
            }
            try
            {
                this.StartingDate = DateTime.ParseExact(startingDate, "yyyy-MM-d", CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid DateTime format!");
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.StringValidator
                    (value, GlobalConstants.MinCourseNameLength,
                    GlobalConstants.MaxCourseNameLength,
                    GlobalMessages.CourseNameLength());
                this.name = value;
            }
        }
        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }
            set
            {
                Validator.NumberValidator
                    (value, GlobalConstants.MinLecturesPerWeeek,
                    GlobalConstants.MaxLecturesPerWeeek,
                    GlobalMessages.LecturesPerWeeek());
                this.lecturesPerWeek = value;
            }
        }
        public DateTime StartingDate
        {
            get
            {
                return this.startingDate;
            }
            set
            {
                this.startingDate = value;
            }
        }
        public DateTime EndingDate
        {
            get
            {
                return this.startingDate.AddDays(GlobalConstants.CourseTimeSpan);
            }
            set
            {
            }
        }

        public IList<IStudent> OnsiteStudents
        {
            get
            {
                return this.onsiteStudents;
            }
            set 
            {
                this.onsiteStudents = value;
            }
        }
        public IList<IStudent> OnlineStudents
        {
            get
            {
                return this.onlineStudents;
            }
            set
            {
                this.onlineStudents = value;
            }
        }
        public IList<ILecture> Lectures
        {
            get
            {
                return this.lectures;
            }
            set
            {
                this.lectures = value;
            }
        }
        
        public override string ToString()
        {
            return string.Format(
            "* Course:\n - Name: {0}\n - Lectures per week: {1}\n - Starting date: {2}\n - Ending date: {3}\n - Onsite students: {4}\n - Online students: {5}\n - Lectures:\n{6}",
            this.name,
            this.lecturesPerWeek,
            this.startingDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.CurrentCulture),
            this.EndingDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.CurrentCulture),
            this.onsiteStudents.Count,
            this.onlineStudents.Count,
            Toolbox.PrintEnumerable(this.lectures, GlobalConstants.NoLecturesMessage));
        }
    }
}
