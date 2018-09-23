using Academy.Models.Abstract;
using Academy.Models.Utils;
using System;
using System.Globalization;

namespace Academy.Models
{
    public class VideoResource : Resource
    {
        private readonly string type;
        private DateTime uploadedOn;

        public VideoResource(DateTime uploadedOn, string name, string url) : base(name, url)
        {
            this.type = GlobalConstants.VideoResourceType;
            this.UploadedOn = uploadedOn;
        }

        public DateTime UploadedOn
        {
            get
            {
                return this.uploadedOn;
            }
            set
            {
                this.uploadedOn = value;
            }
        }

        public override string ResourceType()
        {
            return this.type;
        }

        public override string ToString()
        {
            return string.Format("{0}\n     - Uploaded on: {1}",
                base.ToString(),
                this.uploadedOn.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.CurrentCulture)); 
        }
    }
}
