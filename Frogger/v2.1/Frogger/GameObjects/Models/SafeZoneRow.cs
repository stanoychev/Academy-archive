using Engine;
using System;

namespace GameObjects
{
    public class SafeZoneRow : ISafeZoneRow
    {
        private readonly IFrog frog;
        private readonly int rowID;
        private readonly ISettings settings;

        public SafeZoneRow(IFrog frog, int rowID, ISettings settings)
        {
            this.frog = frog;
            this.rowID = rowID;
            this.settings = settings;
        }

        private bool HasFrog
        {
            get
            {
                if (this.rowID == this.frog.Row)
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
                    new string(' ', this.frog.X),
                    this.frog.ToString().Split('*')[0],
                    this.frog.ToString().Split('*')[1],
                    this.frog.ToString().Split('*')[2],
                    new string(' ', this.settings.ScreenWidth - 1 - this.frog.X - this.frog.FrogDisplayLength));
            }
            else
            {
                //return "\n*";
                return string.Format("{0}*{0}*{0}", new string(' ', this.settings.ScreenWidth - 1));
            }
        }
    }
}
