using GameObjects;
using System;
using System.Linq;
using Utils;

namespace Engine
{
    public class ConsoleKeyReader : IConsoleKeyReader
    {
        public void UpdateFrogPosition(IFrog frog)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: frog.Row--; break;
                    case ConsoleKey.DownArrow: frog.Row++; break;
                    case ConsoleKey.LeftArrow: frog.X -= GlobalConstants.frogXIncrement; break;
                    case ConsoleKey.RightArrow: frog.X += GlobalConstants.frogXIncrement; break;
                    case ConsoleKey.Escape: Environment.Exit(0); break;
                    //for dark hacking and game testing only
                    case ConsoleKey.OemMinus: GlobalConstants.engineClockRatio += 10; break;
                    case ConsoleKey.OemPlus: if (GlobalConstants.engineClockRatio >= 10) GlobalConstants.engineClockRatio -= 10; break;
                    //case ConsoleKey.D1: this.engine.TestConditions = true; this.engine.GameSpeed = 0; break;
                    //case ConsoleKey.D2: this.engine.TestConditions = true; this.engine.GameSpeed = 1; break;
                    //case ConsoleKey.D3: this.engine.TestConditions = true; this.engine.GameSpeed = 2; break;
                    //case ConsoleKey.D4: this.engine.TestConditions = true; this.engine.GameSpeed = 3; break;
                }
            }
        }
    }
}
