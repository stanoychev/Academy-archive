using Frogger.Objects.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Objects.Abstract
{
    public abstract class Subject : ISubject
    {
        private int x;  //frogX максималното е =94, при по-голямо има проблеми
        private int row;

        public Subject()
        {
            //ем, те като се създават обектите не е необходимо да ги инициализирам със стойности
            //защото и без друго веднага ще бъдат overwrite-нати в калкулатора
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                this.row = value;
            }
        }

    }
}
