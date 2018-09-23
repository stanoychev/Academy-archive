using System;
using Utils;

namespace GameObjects
{
    public class SafeZoneRow : BaseRow, ISafeZoneRow
    {
        public SafeZoneRow(RowID rowID, IFrog frog) : base(rowID, frog)
        {
        }

        private bool HasFrog
        {
            get
            {
                if ((int)base.RowID == base.Frog.Row)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            if (this.HasFrog)
            {
                return string.Format("{0}{1}{4}*{0}{2}{4}*{0}{3}{4}",
                    new string(' ', base.Frog.X),
                    base.Frog.ToString().Split('*')[0],
                    base.Frog.ToString().Split('*')[1],
                    base.Frog.ToString().Split('*')[2],
                    new string(' ', GlobalConstants.screenWidth - 1 - base.Frog.X - base.Frog.FrogDisplayLength));
            }
            else
            {
                //return "\n*";
                return string.Format("{0}*{0}*{0}", new string(' ', GlobalConstants.screenWidth-1));
            }
        }
    }
}
