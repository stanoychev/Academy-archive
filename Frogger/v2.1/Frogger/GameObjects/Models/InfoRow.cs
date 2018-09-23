using System.Linq;

namespace GameObjects
{
    public class InfoRow : IInfoRow
    {
        private int gameSpeed;
        private int gameScore;
        private readonly IFrog frog;
        private readonly int rowID;

        public InfoRow(IFrog frog, int rowID)
        {
            this.frog = frog;
            this.rowID = rowID;

        }

        public int GameSpeed
        {
            set
            {
                this.gameSpeed = value;
            }
        }

        public int GameScore
        {
            set
            {
                this.gameScore = value;
            }
        }
        
        public override string ToString()
        {
            return string.Format(
                "{0}{1}{2}{3}{2}{3}{2}{4}*{0}{5}{6}{7}{5}{8}{9}{5}{10}{11}{5}*{0}{12}{2}{13}{2}{13}{2}{14}",
                new string(' ', 11),    //0
                '┌',                    //1
                new string('─', 25),    //2
                '┬',                    //3
                '┐',                    //4
                '|',                                                                        //5
                "SPEED:".PadLeft(13),                                                       //6
                this.gameSpeed.ToString().PadRight(12),                                     //7
                "LIVES:".PadLeft(12),                                                       //8
                string.Concat(Enumerable.Repeat("♥ ", this.frog.Lives)).PadRight(13), //9
                "SCORE:".PadLeft(13),                                                       //10
                this.gameScore.ToString().PadRight(12),                                     //11
                '└',                                                                        //12
                '┴',                                                                        //13
                '┘');                                                                       //14
        }
    }
}