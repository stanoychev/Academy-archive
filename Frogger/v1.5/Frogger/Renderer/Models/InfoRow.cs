using Frogger.Objects.Models;
using Frogger.Renderer.Abstract;
using Frogger.Renderer.Contracts;
using Frogger.Renderer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer
{
    public class InfoRow : BaseRow, IRowID
    {
        public InfoRow(RowID initialRowID) : base (initialRowID)
        {
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
                base.GameSpeed.ToString().PadRight(12), //7
                "LIVES:".PadLeft(12),               //8
                string.Concat(Enumerable.Repeat("♥ ", Frog.Instance.Lives)).PadRight(13),    //9
                "SCORE:".PadLeft(13),                                               //10
                base.Score.ToString().PadRight(12), //11
                '└',                                //12
                '┴',                                //13
                '┘');                               //14
        }
    }
}