using Frogger.Objects.Abstract;
using Frogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Objects.Models
{
    public class Frog : Subject, IFrog
    {
        private int lives;
        private bool isAlive;
        private int level;

        public Frog() : base()
        {
            base.X = GlobalConstants.initialFrogX;
            base.Row = GlobalConstants.initialFrogRow;
            this.lives = GlobalConstants.initialFrogLives;
            this.level = GlobalConstants.initialFrogLevel;
            //жабата се създава само веднъж в блатото (Swamp)
            //при създаването не е необходимо въвеждане на стойности,
            //в калкулатора ще се сменят и без друго
        }

        public int Lives
        {
            get
            {
                return this.lives;
            }
            set
            {
                this.lives = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                if (this.lives >= 1)
                {
                    return true;
                }
                else return false;
            }
            set
            {
                this.isAlive = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}*{1}*{2}",
            " @ @ ",
            "\\(_)/",
            " \\ / ");
        }
    }
}
