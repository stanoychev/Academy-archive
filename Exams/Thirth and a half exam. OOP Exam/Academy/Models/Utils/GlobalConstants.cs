using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Utils
{
    public class GlobalConstants
    {
        public const string NoLecturesMessage = "  * There are no lectures in this course!"; //checked
        public const string NoCourseResults = "  * User has no course results!"; //checked
        public const string NoResourcesResults = "    * There are no resources in this lecture."; //checked
        public const string NoUsers = "There are no registered users!"; //checked
        public const int MinCourseNameLength = 3;
        public const int MaxCourseNameLength = 45;
        public const int MinUsernameLength = 3;
        public const int MaxUsernameLength = 16;
        public const int MinLecturesPerWeeek = 1;
        public const int MaxLecturesPerWeeek = 7;
        public const string InvalidTrack = "The provided track is not valid!"; //checked
        public const float MinExamPoints = 0f;
        public const float MaxExamPoints = 1000f;
        public const float MinCoursePoints = 0f;
        public const float MaxCoursePoints = 125f;
        public const int MinLectureNameLength = 5;
        public const int MaxLectureNameLength = 30;
        public const int MinResourceNameLength = 3;
        public const int MaxResourceNameLength = 15;
        public const int MinUrlLength = 5;
        public const int MaxUrlLength = 150;
        public const string VideoResourceType = "Video";
        public const string PresentationResourceType = "Presentation";
        public const string DemoResourceType = "Demo";
        public const string HomeworkResourceType = "Homework";
        public const double HomeworkTerm = 7.0;
        public const double CourseTimeSpan = 30.0;
    }
}
