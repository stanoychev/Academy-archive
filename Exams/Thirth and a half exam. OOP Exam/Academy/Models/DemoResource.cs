using Academy.Models.Abstract;
using Academy.Models.Contracts;
using Academy.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class DemoResource : Resource, ILectureResource
    {
        private readonly string type;

        public DemoResource(string name, string url) : base(name, url)
        {
            this.type = GlobalConstants.DemoResourceType;
        }
        
        public override string ResourceType()
        {
            return this.type;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
