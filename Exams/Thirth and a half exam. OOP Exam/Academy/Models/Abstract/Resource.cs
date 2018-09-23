using Academy.Models.Contracts;
using Academy.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Abstract
{
    public abstract class Resource : ILectureResource
    {
        private string name;
        private string url;

        public Resource(string name, string url)
        {
            this.Name = name;
            this.Url = url;
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
                    GlobalConstants.MinResourceNameLength,
                    GlobalConstants.MaxResourceNameLength,
                    GlobalMessages.ValidResourceName());
                this.name = value;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                Validator.StringValidator(value,
                    GlobalConstants.MinUrlLength,
                    GlobalConstants.MaxUrlLength,
                    GlobalMessages.ValidUrlName());
                this.url = value;
            }
        }

        public virtual string ResourceType()
        {
            return "ResourceType";
        }

        public override string ToString()
        {
            return string.Format("    * Resource:\n     - Name: {0}\n     - Url: {1}\n     - Type: {2}",
                this.name,
                this.url,
                ResourceType());
        }
    }
}
