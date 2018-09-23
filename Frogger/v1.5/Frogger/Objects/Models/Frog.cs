using Frogger.Objects.Abstract;
using Frogger.Renderer;
using Frogger.Renderer.Abstract;
using Frogger.Renderer.Enums;
using Frogger.Renderer.Models;
using Frogger.Renderer.RowCollection;
using Frogger.Utils;
using System;
using System.Linq;
using System.Drawing;

namespace Frogger.Objects.Models
{
    public class Frog : Subject, IFrog
    {
        private static readonly Frog instance = new Frog();
        private bool isAlive;
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

        private Frog() : base()
        {
            base.X = GlobalConstants.initialFrogX;
            base.Row = GlobalConstants.initialFrogRow;
            this.lives = GlobalConstants.initialFrogLives;
            this.frogLevel = GlobalConstants.initialFrogLevel;
        }

        public static Frog Instance
        {
            get
            {
                return instance;
            }
        }
        
        public int X
        {
            get
            {
                return base.X;
            }
            set
            {
                if (value >= GlobalConstants.FrogMinX && value <= GlobalConstants.FrogMaxX)
                {
                    base.X = value;
                }
                else if (value > GlobalConstants.FrogMaxX)
                {
                    base.X = GlobalConstants.FrogMaxX;
                }
                else
                {
                    base.X = 0;
                }
            }
        }

        public int Row
        {
            get
            {
                return base.Row;
            }
            set
            {
                if (IsFrogOnAnAowedRow(value))
                {
                    base.Row = value;
                    if (base.Row == 1)
                    {
                        //this can be done more elegantly with an event
                        this.FrogLevel++;
                        ((BaseRow)RowCollection.Instance.Rows.ElementAt(0)).Score++;
                        ((BaseRow)RowCollection.Instance.Rows.ElementAt(0)).GameSpeed++;
                        Renderer.Renderer.Execute();
                        ConsoleKeyInfo _ = Console.ReadKey();
                        if (this.frogLevel == GlobalConstants.maxFrogLevel)
                        {
                            Console.Clear();
                            Console.WriteLine(GlobalConstants.wellDoneFrogger);
                            Environment.Exit(0);
                        }
                        ResetFrogPosition();
                    }
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
                if (value >= 0)
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
            set
            {
                this.isAlive = value;
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
                return base.X + FrogDisplayLength - 1;
            }
        }

        private bool IsFrogOnAnAowedRow(int row)
        {
            //for further development
            //this can be elegantly resolved using the reflection technique, something currently I know nothing about
            return row >= (int)RowID.First && row <= GlobalConstants.gameRows - 1;
        }

        private void ResetFrogPosition()
        {
            if (base.Row > 1
                &&
                base.Row <= GlobalConstants.midLevelFrogRow
                &&
                this.FrogLevel >= 2)
            {
                base.Row = GlobalConstants.midLevelFrogRow;
                base.X = GlobalConstants.initialFrogX;
            }
            else
            {
                base.Row = GlobalConstants.initialFrogRow;
                base.X = GlobalConstants.initialFrogX;
            }
        }

        public void CheckForCollision()
        {
            //this can be done more elegantly with an event
            if ((base.Row >= (int)RowID.Second && base.Row <= (int)RowID.Seventh)
                ||
                (base.Row >= (int)RowID.Ninth && base.Row <= (int)RowID.Fourteenth))
            {
                if ((base.X >= ((LaneRow)RowCollection.Instance.Rows.ElementAt(base.Row)).VehicleOnTheRow.X
                    &&
                    base.X <= ((LaneRow)RowCollection.Instance.Rows.ElementAt(base.Row)).VehicleOnTheRow.VehicleEndX)
                    ||
                    (base.X + this.FrogDisplayLength - 1 >= ((LaneRow)RowCollection.Instance.Rows.ElementAt(base.Row)).VehicleOnTheRow.X
                    &&
                    base.X + this.FrogDisplayLength - 1 <= ((LaneRow)RowCollection.Instance.Rows.ElementAt(base.Row)).VehicleOnTheRow.VehicleEndX))
                {
                    Renderer.Renderer.Execute();
                    this.lives--;
                    ConsoleKeyInfo _ = Console.ReadKey();
                    ResetFrogPosition();
                }
            }
        }

        public void UpdateFrogPosition()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: this.Row--; break;
                    case ConsoleKey.DownArrow: this.Row++; break;
                    case ConsoleKey.LeftArrow: this.X-= GlobalConstants.frogXIncrement; break;
                    case ConsoleKey.RightArrow: this.X+= GlobalConstants.frogXIncrement; break;
                    case ConsoleKey.Escape: Environment.Exit(0); break;
                    //for game testing only
                    case ConsoleKey.OemMinus: GlobalConstants.engineClockRatio += 10; break;
                    case ConsoleKey.OemPlus: if (GlobalConstants.engineClockRatio >= 10) GlobalConstants.engineClockRatio -= 10; break;
                    case ConsoleKey.D1: ((BaseRow)RowCollection.Instance.Rows.ElementAt(0)).GameSpeed = 0; break;
                    case ConsoleKey.D2: ((BaseRow)RowCollection.Instance.Rows.ElementAt(0)).GameSpeed = 1; break;
                    case ConsoleKey.D3: ((BaseRow)RowCollection.Instance.Rows.ElementAt(0)).GameSpeed = 2; break;
                    case ConsoleKey.D4: ((BaseRow)RowCollection.Instance.Rows.ElementAt(0)).GameSpeed = 3; break;
                }
            }
        }
        
        public override string ToString()
        {
            return this.frogDysplayCondition[GlobalConstants.initialFrogLives - (this.Lives)];
        }
    }
}
