using Frogger.Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Objects.Models
{
    public class Swamp
    {
        //в engine-а като се зарежда играта трябва да се викне инстанция на жабата
        //тук в блатото има създадена една жаба повече не може
        private static readonly Frog instance = new Frog();

        private Swamp()
        {
            this.Frog = new Frog();
        }

        public IFrog Frog
        {
            get;
            private set;
        }

        public static Frog Instance
        {
            get
            {
                return instance;
            }
        }


    }
}
