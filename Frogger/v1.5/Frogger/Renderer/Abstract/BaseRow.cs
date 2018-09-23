using Frogger.Renderer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frogger.Renderer.Enums;
using Frogger.Objects.Models;
using Frogger.Utils;

namespace Frogger.Renderer.Abstract
{
    public abstract class BaseRow : IRow
    {
        private int gameSpeed;
        private int score;
        private readonly RowID rowID;

        public BaseRow(RowID initialRowID)
        {
            this.GameSpeed = GlobalConstants.gameSpeedMin;
            this.Score = GlobalConstants.initialGameScore;
            this.rowID = initialRowID;
        }
        
        public RowID RowID
        {
            get
            {
                return this.rowID;
            }
        }

        public bool HasFrog
        {
            get
            {
                if ((int)RowID == Frog.Instance.Row)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int GameSpeed
        {
            get
            {
                return this.gameSpeed;
            }
            set
            {
                if (value>0)
                {
                    this.gameSpeed = value;
                }
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }
    }
}
