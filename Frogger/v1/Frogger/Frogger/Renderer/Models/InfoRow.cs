using Frogger.Objects.Models;
using Frogger.Renderer.Contracts;
using Frogger.Renderer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer
{
    public class InfoRow : IInfoRow, IRowID
    {
        //този ред е най горния и е със специална имплементация и не наследява никой
        //само трябва да вземе от някъде SPEED, LIVES и SCORE, които да display-ва
        private int speed;
        private int score;
        private readonly RowID rowID;
        //при инициализирането на обектите в колекцията им се слага rowID и повече не се бара.

        public InfoRow(RowID initialRowID)
        {
            //default-ен конструктор, ползвам го при инициализацията на модела
            this.rowID = initialRowID;
        }

        public RowID RowID
        {
            get
            {
                return this.rowID;
            }
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = value;
            }
        }

        public int Lives
        {
            get
            {
                return Swamp.Instance.Lives;
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

        public override string ToString()
        {
            return string.Format(
                "{0}{1}{2}{3}{2}{3}{2}{4}*{0}{5}{6}{7}{5}{8}{9}{5}{10}{11}{5}*{0}{12}{2}{13}{2}{13}{2}{14}",
                new string(' ', 11),    //0
                '┌',                    //1
                new string('─', 25),    //2
                '┬',                    //3
                '┐',                    //4
                '|',                    //5
                "SPEED:".PadLeft(13),   //6
                this.Speed.ToString().PadRight(12), //7
                "LIVES:".PadLeft(13),               //8
                string.Concat(Enumerable.Repeat("♥ ", this.Lives)).PadRight(12),    //9
                "SCORE:".PadLeft(13),                                               //10
                this.Score.ToString().PadRight(12), //11
                '└',                                //12
                '┴',                                //13
                '┘');                               //14
        }
    }
}

/* старо
 * //Заради шаренията по конзолата не съм го направил на ToString() от inforow-a
                    InfoRow inforow = (InfoRow)RowCollection.RowCollection.Instance.Rows.First();
                    int speed = inforow.Speed;
                    int lives = inforow.Lives;
                    int score = inforow.Score;
                    //тва ако е мега бавно, ще взимам от калкулатора направо:  public static void Execute(int[] frogXRow, IDictionary<int, int> vehicleXRow, int speed, int lives, int score)

                    
                    Console.SetCursorPosition(10, 0);
                    Console.WriteLine("{4}{0}{3}{1}{3}{1}{3}{2}", '┌', '┬', '┐', new string('─', 25), new string (' '), 11);
                    Console.SetCursorPosition(10, 1);
                    
                    Console.SetCursorPosition(10, 2);
                    Console.WriteLine("{0}{3}{1}{3}{1}{3}{2}", '└', '┴', '┘', new string('─', 25));

                    //RowCollection.RowCollection.Instance.Rows.Add(new InfoRow());
*/
