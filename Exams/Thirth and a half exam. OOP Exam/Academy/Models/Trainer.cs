using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Models
{
    public class Trainer : User, ITrainer
    {
        private IList<string> technologies = new List<string>();

        public Trainer(string username, string technologies) : base(username)
        {
            this.Technologies = technologies.Split(',');
        }

        public IList<string> Technologies
        {
            get
            {
                return this.technologies;
            }
            set
            {
                this.technologies = value;
            }
        }

        public override string PersonType()
        {
            return "Trainer";
        }

        public override string ToString()
        {
            return string.Format("{0}\n - Technologies: {1}",
                base.ToString(),
                String.Join("; ", this.technologies.ToArray()));
        }
    }
}
