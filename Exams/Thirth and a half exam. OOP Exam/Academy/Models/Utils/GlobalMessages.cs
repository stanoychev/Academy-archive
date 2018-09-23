using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Utils
{
    public static class GlobalMessages
    {
        public static string CourseNameLength
            (int minLength = GlobalConstants.MinCourseNameLength,
            int maxLength = GlobalConstants.MaxCourseNameLength)
        {
            return string.Format("The name of the course must be between {0} and {1} symbols!",
                minLength, maxLength);
        }

        public static string LecturesPerWeeek
            (int min = GlobalConstants.MinLecturesPerWeeek,
            int max = GlobalConstants.MaxLecturesPerWeeek)
        {
            return string.Format("The number of lectures per week must be between {0} and {1}!",
                min, max);
        }

        public static string UserNameLength
            (int minLength = GlobalConstants.MinUsernameLength,
            int maxLength = GlobalConstants.MaxUsernameLength)
        {
            return string.Format("User's username should be between {0} and {1} symbols long!",
                minLength, maxLength);
        }

        public static string ValidExamPoints
            (float minPoints = GlobalConstants.MinExamPoints,
            float maxPoints = GlobalConstants.MaxExamPoints)
        {
            return string.Format("Course result's exam points should be between {0} and {1}!",
                (int)minPoints, (int)maxPoints);
        }

        public static string ValidCoursePoints
            (float minPoints = GlobalConstants.MinCoursePoints,
            float maxPoints = GlobalConstants.MaxCoursePoints)
        {
            return string.Format("Course result's course points should be between {0} and {1}!",
                (int)minPoints, (int)maxPoints);
        }
        
        public static string ValidLectureName
            (int minLength = GlobalConstants.MinLectureNameLength,
            int maxLength = GlobalConstants.MaxLectureNameLength)
        {
            return string.Format("Lecture's name should be between {0} and {1} symbols long!",
                minLength, maxLength);
        }

        public static string ValidResourceName
            (int minLength = GlobalConstants.MinResourceNameLength,
            int maxLength = GlobalConstants.MaxResourceNameLength)
        {
            return string.Format("Resource name should be between {0} and {1} symbols long!",
                minLength, maxLength);
        }

        public static string ValidUrlName
            (int minLength = GlobalConstants.MinUrlLength,
            int maxLength = GlobalConstants.MaxUrlLength)
        {
            return string.Format("Resource url should be between {0} and {1} symbols long!",
                minLength, maxLength);
        }
    }
}
