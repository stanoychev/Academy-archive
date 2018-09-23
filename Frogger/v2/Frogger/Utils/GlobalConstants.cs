using Engine;

namespace Utils
{
    public static class GlobalConstants
    {
        //game settings
        public const int screenWidth = 100; //for further development
        public const int screenHeight = gameRows * 3 + 1; //for further development
        public static int engineClockRatio = 60;
        public const int gameRows = 16; //for further development
        public const int gameSpeedMin = 0;
        public const int gameSpeedMax = 3;
        public const int initialGameScore = 0;

        //Screens
        public static string welcomeFrogger = Screens.WellcomeScreen();
        public static string wellDoneFrogger = Screens.WellDoneScreen();
        public static string gameOverFrogger = Screens.GameOverScreen();

        //Frog settings
        public const int FrogMinX = 0;
        public static int FrogMaxX = GlobalMethods.GetFrogMaxX();
        public const int FrogMinRow = 1;
        public const int FrogMaxRow = gameRows - 1;
        public const int initialFrogX = 50;
        public const int initialFrogRow = 15;
        public const int midLevelFrogRow = initialFrogRow / 2 + initialFrogRow % 2;

        /*
         * 
        
        

         * 
         * */

        //public static Point initialFrogPosition = new Point (initialFrogX, initialFrogRow);
        //public static Point middleFrogPosition = new Point(initialFrogX, initialFrogRow / 2 + initialFrogRow % 2);

        //public static Rectangle allowableFrogPosition = new Rectangle(0,1,screenWidth,gameRows-1); // ili bez -1
        //public static Point upperLeftCorner = new Point(0,1);
        //public static Point downRightCorner = new Point(GlobalMethods.GetFrogMaxX(),gameRows-1);


        public const int initialFrogLives = 5;
        public const int initialFrogLevel = 0;
        public const int maxFrogLevel = 5;
        public const int frogXIncrement = 10;

        //Vehicle settings
        
        //public static Rectangle allowableVehiclePosition = new Rectangle(0, 1, screenWidth, 1); //ili 0
        //public static Point upperLeftCorner = new Point(0, 1);
        //public static Point downRightCorner = new Point(GlobalMethods.GetFrogMaxX(), gameRows - 1);

        public const int vehicleMinX = 0;
        public const int vehicleMaxX = screenWidth - 1;
        public const int vehicleMinRow = 0;
        public const int vehicleMaxRow = screenWidth - 1;
        public const int vehicleFillMultiplierMin = 1;
        public const int vehicleFillMultiplierMax = 5;
        public const int vehicleMinSpeed = 1;
        public const int vehicleMaxSpeed = 5;
    }
}
