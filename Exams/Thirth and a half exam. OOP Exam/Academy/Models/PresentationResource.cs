using Academy.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Utils;


namespace Academy.Models
{
    public class PresentationResource: Resource
    {
        private readonly string type;

        public PresentationResource(string name, string url) : base(name, url)
        {
            this.type = GlobalConstants.PresentationResourceType;
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
