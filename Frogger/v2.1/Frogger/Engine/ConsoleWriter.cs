using GameObjects;
using System;
using System.Threading;

namespace Engine
{
    public class ConsoleWriter : IConsoleWriter
    {
        private readonly IRowCollection rowCollection;
        private readonly ISettings settings;
        private readonly IFrog frog;


        public ConsoleWriter(IRowCollection rowCollection, ISettings settings, IFrog frog)
        {
            this.rowCollection = rowCollection;
            this.settings = settings;
            this.frog = frog;
        }

        public void Render()
        {
            Console.Clear();
            for (int rowID = 0; rowID <= this.settings.GameRows-1; rowID++)
            {
                foreach (string item in this.rowCollection.Rows[rowID].ToString().Split('*'))
                {
                    Console.WriteLine(item);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Thread.Sleep(this.settings.EngineClockRatio);
        }

        public void GameFreeze()
        {
            Render();
            Console.ReadKey();
        }

        public void SetWindowDimentions()
        {
            if (this.settings.GameReadyToStart)
            {
                try
                {
                    Console.SetWindowSize(this.settings.ScreenWidth, this.settings.ScreenHeight);
                    Console.SetBufferSize(this.settings.ScreenWidth, this.settings.ScreenHeight);
                }
                catch
                {
                    string message = "Sorry :(.\nBecause of console width/high limitations the game can not be started at this video mode.\nTry different font and/or screen resolution.\nOn Windows 7 it worked I swear.\nTheGame will be now set to small video mode.\nPress any key to continue...";
                    this.settings.VideoModeSelector = VMode.mode1;
                    Console.Clear();
                    Console.WriteLine(message);
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    this.SetWindowDimentions();
                }
            }
            else throw new ArgumentException("SetWindowDimentions not ready to start");
        }

        public void ExitFrogger(string message)
        {
            //da go premestq v consolereadkey klasa
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("Press ESC to quit or any other key for a new game.");
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            this.frog.Lives = this.settings.InitialFrogLives;
        }

        public void WellcomeFrogger()
        {
            Console.Clear();
            Console.WriteLine(this.settings.WelcomeFrogger);
            Console.ReadKey();
        }

        public void SelectGameSettings(IConsoleReader consoleReader)
        {
            //to improove later
            Console.WriteLine("Select dificulty:");
            Console.WriteLine("Press '1' for easy as drinking water.");
            Console.WriteLine("Press '2' for medium as drinking water that just boiled.");
            Console.WriteLine("Press '3' for hard as drinking water that just boiled while being strangled.");
            consoleReader.SelectGameDificulty(settings);
            
            Console.WriteLine("Select video mode:");
            Console.WriteLine("Press '1' for smaller game");
            Console.WriteLine("Press '2' for bigger game");
            //Console.WriteLine("Enter 'd' for mode3");
            consoleReader.SelectVideoMode(settings);

            Console.Clear();
        }
    }
}