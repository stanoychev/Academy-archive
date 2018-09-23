using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;
using System.Collections.Generic;
using Academy.Models.Utils;
using System;
using System.Linq;
using System.Text;

namespace Academy.Models
{
    public class Student : User, IStudent
    {
        private Track track;
        private IList<ICourseResult> courseResults = new List<ICourseResult>();

        public Student(string username, string track) : base(username)
        {
            try
            {
                this.Track = (Track)Enum.Parse(typeof(Track), track,false);
            }
            catch (Exception)
            {
                throw new ArgumentException(GlobalConstants.InvalidTrack);
            }
        }

        public Track Track
        {
            get
            {
                return this.track;
            }
            set
            {
                Validator.StudentTrackValidator(value);
                this.track = value;
            }
        }
        public IList<ICourseResult> CourseResults
        {
            get
            {
                return this.courseResults;
            }
            set
            {
                this.courseResults = value;
            }
        }

        public override string PersonType()
        {
            return "Student";
        }
        
        public override string ToString()
        {
            return string.Format("{0}\n - Track: {1}\n - Course results:\n{2}",
            base.ToString(),
            this.track.ToString(),
            Toolbox.PrintEnumerable(this.courseResults, GlobalConstants.NoCourseResults));
        }

    }
}
