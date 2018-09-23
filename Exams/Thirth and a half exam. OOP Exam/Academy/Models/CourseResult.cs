using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;
using Academy.Models.Utils;
using Academy.Models.Utils.Contracts;

namespace Academy.Models
{
    public class CourseResult : ICourseResult
    {
        private ICourse course;
        private float examPoints;
        private float coursePoints;

        public CourseResult(ICourse course, string examPoints, string coursePoints)
        {
            this.Course = course;
            
            //if (float.TryParse(examPoints, out var pesho))//bgkoder-a!
            //{
                this.ExamPoints = float.Parse(examPoints);
            //}
            //else
            //{
            //    throw new ArgumentNullException(GlobalMessages.ValidExamPoints());
            //}
            //if (float.TryParse(examPoints, out var gosho))//bgkoder-a!
            //{
                this.CoursePoints = float.Parse(coursePoints);
            //}
            //else
            //{
            //    throw new ArgumentNullException(GlobalMessages.ValidCoursePoints());
            //}
        }

        public ICourse Course
        {
            get
            {
                return this.course;
            }
            private set
            {
                this.course = value;
            }
        }
        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }
            private set
            {
                Validator.NumberValidator(value, GlobalConstants.MinExamPoints,
                    GlobalConstants.MaxExamPoints, GlobalMessages.ValidExamPoints());
                this.examPoints = value;
            }
        }
        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }
            private set
            {
                Validator.NumberValidator(value, GlobalConstants.MinCoursePoints,
                    GlobalConstants.MaxCoursePoints, GlobalMessages.ValidCoursePoints());
                this.coursePoints = value;
            }
        }
        public Grade Grade
        {
            get
            {
                if (examPoints >= 65 || coursePoints >= 75)
                {
                    return Grade.Excellent;
                }
                else if ((examPoints < 60 && examPoints >= 30) ||
                        (coursePoints < 75 && coursePoints >= 45))
                {
                    return Grade.Passed;
                }
                else
                {
                    return Grade.Failed;
                }
            }
        }
        public override string ToString()
        {
            return string.Format("  * {0}: Points - {1}, Grade - {2}",
                this.course.Name,
                (int)this.coursePoints,
                this.Grade);
        }
    }
}
