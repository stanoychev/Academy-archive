using Utils;

namespace GameObjects
{
    public class Frog : IFrog
    {
        private int x;
        private int row;
        private int lives;
        private int frogLevel;
        private readonly string[] frogDysplayCondition = new string[GlobalConstants.initialFrogLives + 1]
        {
            string.Format("{0}*{1}*{2}", " @ @ ", "\\(_)/", " \\ / "),
            string.Format("{0}*{1}*{2}", " @ @ ", "\\---/", " \\ / "),
            string.Format("{0}*{1}*{2}", " @ @ ", " ---/", "/\\ / "),
            string.Format("{0}*{1}*{2}", " @ @ ", " --- ", "/\\ /\\"),
            string.Format("{0}*{1}*{2}", " x @ ", " --- ", "/\\ /\\"),
            string.Format("{0}*{1}*{2}", " x x ", " --- ", "/\\ /\\ ")
        };
       
        public Frog()
        {
            this.x = GlobalConstants.initialFrogX;
            this.row = GlobalConstants.initialFrogRow;
            this.lives = GlobalConstants.initialFrogLives;
            this.frogLevel = GlobalConstants.initialFrogLevel;
        }
        
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (value >= GlobalConstants.FrogMinX && value <= GlobalConstants.FrogMaxX)
                {
                    this.x = value;
                }
                else if (value > GlobalConstants.FrogMaxX)
                {
                    this.x = GlobalConstants.FrogMaxX;
                }
                else
                {
                    this.x = 0;
                }
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
                if (value >= (int)RowID.Row1 && value <= GlobalConstants.gameRows - 1)
                {
                    this.row = value;
                }
            }
        }

        public int Lives
        {
            get
            {
                return this.lives;
            }
            set
            {
                if (value >= 0 && value<=GlobalConstants.initialFrogLives)
                {
                    this.lives = value;
                }
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
        }

        //public int FrogLevel
        //{
        //    get
        //    {
        //        return this.frogLevel;
        //    }
        //    set
        //    {
        //        this.frogLevel = value;
        //    }
        //}

        public int FrogDisplayLength
        {
            get
            {
                return ToString().Split('*')[0].Length;
            }
        }

        public int FrogEndX
        {
            get
            {
                return this.x + FrogDisplayLength - 1;
            }
        }

        public int FrogLevel
        {
            get
            {
                return this.frogLevel;
            }
            set
            {
                this.frogLevel = value;
            }
        }
        
        //private void ResetFrogPosition()
        //{
        //    if (this.row > 1 && this.row <= GlobalConstants.midLevelFrogRow && this.frogLevel >= 2)
        //    {
        //        this.row = GlobalConstants.midLevelFrogRow;
        //        this.x = GlobalConstants.initialFrogX;
        //    }
        //    else
        //    {
        //        this.row = GlobalConstants.initialFrogRow;
        //        this.x = GlobalConstants.initialFrogX;
        //    }
        //}

        //public void CheckForCollision()
        //{
        //    //this can be done more elegantly with an event
        //    if ((this.row >= (int)RowID.Row2 && this.row <= (int)RowID.Row7)
        //        ||
        //        (this.row >= (int)RowID.Row9 && this.row <= (int)RowID.Row14))
        //    {
        //        if ((this.x >= ((LaneRow)RowCollection.Instance.Rows.ElementAt(this.row)).VehicleOnTheRow.X
        //            &&
        //            this.x <= ((LaneRow)RowCollection.Instance.Rows.ElementAt(this.row)).VehicleOnTheRow.VehicleEndX)
        //            ||
        //            (this.x + this.FrogDisplayLength - 1 >= ((LaneRow)RowCollection.Instance.Rows.ElementAt(this.row)).VehicleOnTheRow.X
        //            &&
        //            this.x + this.FrogDisplayLength - 1 <= ((LaneRow)RowCollection.Instance.Rows.ElementAt(this.row)).VehicleOnTheRow.VehicleEndX))
        //        {
        //            this.lives--;
        //            GlobalMethods.GameFreeze();
        //            ResetFrogPosition();
        //        }
        //    }
        //}
        
        public override string ToString()
        {
            return this.frogDysplayCondition[GlobalConstants.initialFrogLives - (this.Lives)];
        }
    }
}
