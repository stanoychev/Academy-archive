using GameObjects;
using System;

namespace Engine
{
    public class ConsoleReader : IConsoleReader
    {
        public void UpdateFrogPosition(IFrog frog, ISettings settings)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow: frog.Row--; break;
                    case ConsoleKey.DownArrow: frog.Row++; break;
                    case ConsoleKey.LeftArrow: frog.X -= settings.FrogXIncrement; break;
                    case ConsoleKey.RightArrow: frog.X += settings.FrogXIncrement; break;
                    case ConsoleKey.Escape: Environment.Exit(0); break;
                    //for dark hacking and game testing only
                    case ConsoleKey.OemMinus: settings.EngineClockRatio += 10; break;
                    case ConsoleKey.OemPlus: settings.EngineClockRatio -= 10; break;
                    case ConsoleKey.D1: settings.TestConditions = true; settings.GameSpeed = 0; break;
                    case ConsoleKey.D2: settings.TestConditions = true; settings.GameSpeed = 1; break;
                    case ConsoleKey.D3: settings.TestConditions = true; settings.GameSpeed = 2; break;
                    case ConsoleKey.D4: settings.TestConditions = true; settings.GameSpeed = 3; break;
                    case ConsoleKey.D5: settings.TestConditions = true; settings.GameSpeed = 4; break;
                    case ConsoleKey.D6: settings.TestConditions = true; settings.GameSpeed = 5; break;
                    case ConsoleKey.D7: settings.TestConditions = true; settings.GameSpeed = 6; break;
                }
            }
        }

        public void SelectGameDificulty(ISettings settings)
        {
            bool notExecuted = true;
            while (notExecuted)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1: settings.GameDificulty = GameDificulty.easy; notExecuted = false; break;
                    case ConsoleKey.D2: settings.GameDificulty = GameDificulty.medium; notExecuted = false; break;
                    case ConsoleKey.D3: settings.GameDificulty = GameDificulty.hard; notExecuted = false; break;
                    case ConsoleKey.Escape: Environment.Exit(0); break;
                }
            }
        }

        public void SelectVideoMode(ISettings settings)
        {
            bool notExecuted = true;
            while (notExecuted)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                case ConsoleKey.D1: settings.VideoModeSelector = VMode.mode1; notExecuted = false; break;
                case ConsoleKey.D2: settings.VideoModeSelector = VMode.mode2; notExecuted = false; break;
                case ConsoleKey.Escape: Environment.Exit(0); break;
                }
            }
        }
    }
}
