using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frogger.Engine.Screens;

namespace Frogger.Utils
{
    public static class GlobalConstants
    {
        public const int screenWidth = 100;
        public const int screenHeight = 49;
        public static int delayer = 60;
        public const int frogStepToTheSides = 3;
        public const int initialFrogX = 48;
        public const int initialFrogRow = 15;
        public const int initialFrogLives = 3;
        public static string welcomeFrogger = Screens.WellcomeScreen();
        public static string wellDoneFrogger = Screens.WellDoneScreen();
        public static string gameOverFrogger = Screens.GameOverScreen();
        public const int initialFrogLevel = 0;
        public const int maxFrogLevel = 3;
    }
}
