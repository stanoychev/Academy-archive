using Frogger.Renderer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer.RowCollection
{
    public class RowCollection : IRowCollection
    {
        private static readonly RowCollection instance = new RowCollection();

        private RowCollection()
        {
            this.Rows = new List<IRowID>();
            //this.Rows = new IRowID[16];
        }

        public ICollection<IRowID> Rows
        //public IRowID[] Rows
        {
            get;
            private set;
        }

        public static RowCollection Instance
        {
            get
            {
                return instance;
            }
        }
        
    }
}
/*
* Да измисля как в началото на играта да се създадат всички обекти от тип Row и после само 
* да им се сменят стойностите вътре в колекцията
* 
* Готово Engine-a вика методите от Renderer-a
* 
* Singleton pattern: ако искаме да сме сигурни, че през цялото време ще имаме само една инстанция
* в случая искам само 1 списък с Row-ове => Singleton pattern it is за колекцията с редове
* 
* мислех да е фиксиран масив с 15 елемента, но нещо пищи, че не можело да се ползва [] и за това давам List, бонус upgrade-able е
* 
* 
*/
