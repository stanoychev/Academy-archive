using Engine;
using System;

namespace GameObjects
{
    public class Frog : IFrog
    {
        private int x;
        private int row;
        private int lives;
        private int frogLevel;
        private readonly string[] frogDysplayCondition = new string[]
        {
            string.Format("{0}*{1}*{2}", " @ @ ", "\\(_)/", " \\ / "),
            string.Format("{0}*{1}*{2}", " @ @ ", "\\---/", " \\ / "),
            string.Format("{0}*{1}*{2}", " @ @ ", " ---/", "/\\ / "),
            string.Format("{0}*{1}*{2}", " @ @ ", " --- ", "/\\ /\\"),
            string.Format("{0}*{1}*{2}", " x @ ", " --- ", "/\\ /\\"),
            string.Format("{0}*{1}*{2}", " x x ", " --- ", "/\\ /\\ ")
        };
        private ISettings settings;
        
        public Frog(ISettings settings)
        {
            this.settings = settings;
            this.lives = this.settings.InitialFrogLives;
            this.frogLevel = this.settings.InitialFrogLevel;
        }
        
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (this.settings.GameReadyToStart)
                {
                    if (value >= this.settings.FrogMinX
                        &&
                        value <= this.settings.FrogMaxX(this.FrogDisplayLength))
                    {
                        this.x = value;
                    }
                    else if (value > this.settings.FrogMaxX(this.FrogDisplayLength))
                    {
                        this.x = this.settings.FrogMaxX(this.FrogDisplayLength);
                    }
                    else
                    {
                        this.x = 0;
                    }
                }
                else throw new ArgumentException("Game not ready to start!");
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
                if (this.settings.GameReadyToStart) //da probvam posle bez tva
                {
                    if (value >= 1 && value <= this.settings.GameRows - 1) //trqbva pyrvo da e setnato ot engine-a
                    {
                        this.row = value;
                    }
                }
                else throw new ArgumentException("Game not ready to start!");
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
                if (value >= 0 && value<= this.settings.InitialFrogLives)
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
        
        public override string ToString()
        {
            return this.frogDysplayCondition[this.settings.InitialFrogLives - (this.Lives)];
        }
    }
}
