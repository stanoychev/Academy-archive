using GameObjects;

namespace Engine
{
    public class Settings : ISettings
    {
        //game fine settings and initial conditions
        private bool[] gameReadyToStart = new bool[] { false, false };
        private bool testConditions;
        private bool engineDemand;
        private int engineClockRatio = 60;
        private int gameSpeed;
        private int gameScore;
        private const int gameSpeedMin = 0;
        private const int gameSpeedMax = 3;
        private const int initialGameScore = 0; //na kraq kato pita iska6 li pak da igrae6 da se resetne ot tuk

        //Screens
        private string welcomeFrogger = Screens.WellcomeScreen();
        private string wellDoneFrogger = Screens.WellDoneScreen();
        private string gameOverFrogger = Screens.GameOverScreen();

        //Frog settings
        private const int frogMinX = 0;
        private const int frogMinRow = 1;
        private int frogMaxRow; //zavisi ot mode-a
        private int initialFrogX;
        private int initialFrogRow;
        private int midLevelFrogRow;
        private const int initialFrogLives = 5;
        private const int initialFrogLevel = 0;
        private const int maxFrogLevel = 5; //po natatyk za high score tva e za kofata
        private const int frogXIncrement = 10;

        //Vehicle settings
        private const int vehicleMinX = 0;
        private const int vehicleFillMultiplierMin = 1;
        private const int vehicleFillMultiplierMax = 5;
        private const int vehicleMinSpeed = 1;
        private const int vehicleMaxSpeed = 5;

        //Dificulty settings, set by the Property "GameDificulty"
        private const string easyDificulty = "Easy as drinking water.";
        private const string mediumDificulty = "Medium as drinking water that just boiled.";
        private const string hardDificulty = "Hard as drinking water that just boiled while being strangled.";
        private GameDificulty gameDificulty;

        //Video settings in console mode, set by the Property "VideoModeSelector"
        private VMode videoModeSelector;
        private int[] videoMode; //syntax = { gameRows, screenWidth, screenHeight }
        private int[] safeRowIndexes;
        private int[] laneRowIndexes;
        private const int baseGameRows = 16;
        private const int baseScreenWidth = 100;

        //audio settings

        //performance monitor
        //high records + export/import to file + encription/decription

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

        //game fine settings and initial conditions
        public bool TestConditions
        {
            set
            {
                this.testConditions = value;
            }
        }
        public bool EngineDemand
        {
            set
            {
                this.engineDemand = value;
            }
        }
        public int EngineClockRatio
        {
            get
            {
                return this.engineClockRatio;
            }
            set
            {
                if (value > 0)
                {
                    this.engineClockRatio = value;
                }
            }
        }
        public int GameSpeed
        {
            get
            {
                return this.gameSpeed;
            }
            set
            {
                if (this.engineDemand)
                {
                    if (0 <= value && value <= 3)
                    {
                        this.gameSpeed = value;
                    }
                    this.engineDemand = false;
                }
                if (this.testConditions)
                {
                    if (value>=0)
                    {
                        this.gameSpeed = value;
                    }
                    this.testConditions = false;
                }
            }
        }
        public int GameScore
        {
            get
            {
                return this.gameScore;
            }
            set
            {
                if (value >= 0 && this.engineDemand)
                {
                    this.gameScore = value;
                    this.engineDemand = false;
                }
            }
        }
        public int GameSpeedMin
        {
            get
            {
                return gameSpeedMin;
            }
        }
        public int GameSpeedMax
        {
            get
            {
                return gameSpeedMax;
            }
        }
        public int InitialGameScore
        {
            get
            {
                return initialGameScore;
            }
        }
        public bool GameReadyToStart
        {
            get
            {
                bool start = true;
                foreach (bool item in gameReadyToStart)
                {
                    if (item == false)
                    {
                        start = false;
                    }
                }
                return start;
            }
        }

        //Screens
        public string WelcomeFrogger
        {
            get
            {
                return welcomeFrogger;
            }
        }
        public string WellDoneFrogger
        {
            get
            {
                return wellDoneFrogger;
            }
        }
        public string GameOverFrogger
        {
            get
            {
                return gameOverFrogger;
            }
        }

        //Frog settings
        public int FrogMinX
        {
            get
            {
                return frogMinX;
            }
        }
        public int FrogMinRow
        {
            get
            {
                return frogMinRow;
            }
        }
        public int FrogMaxRow
        {
            get
            {
                return frogMaxRow;
            }
        }
        public int InitialFrogX
        {
            get
            {
                return initialFrogX;
            }
        }
        public int InitialFrogRow
        {
            get
            {
                return initialFrogRow;
            }
        }
        public int MidLevelFrogRow
        {
            get
            {
                return midLevelFrogRow;
            }
        }
        public int InitialFrogLives
        {
            get
            {
                return initialFrogLives;
            }
        }
        public int InitialFrogLevel
        {
            get
            {
                return initialFrogLevel;
            }
        }
        public int MaxFrogLevel
        {
            get
            {
                return maxFrogLevel;
            }
        }
        public int FrogXIncrement
        {
            get
            {
                return frogXIncrement;
            }
        }

        //Vehicle settings
        public int VehicleMinX
        {
            get
            {
                return vehicleMinX;
            }
        }
        //public int VehicleMaxX
        //{
        //    get
        //    {
        //        if (this.GameReadyToStart)
        //        {
        //            return vehicleMaxX;
        //        }
        //        else throw new ArgumentException("Game not ready to start!");

        //    }
        //}
        //public int VehicleMinRow
        //{
        //    get
        //    {
        //        return vehicleMinRow;
        //    }
        //}
        //public int VehicleMaxRow
        //{
        //    get
        //    {
        //        return vehicleMaxRow;
        //    }
        //}
        public int VehicleFillMultiplierMin
        {
            get
            {
                return vehicleFillMultiplierMin;
            }
        }
        public int VehicleFillMultiplierMax
        {
            get
            {
                return vehicleFillMultiplierMax;
            }
        }
        public int VehicleMinSpeed
        {
            get
            {
                return vehicleMinSpeed;
            }
        }
        public int VehicleMaxSpeed
        {
            get
            {
                return vehicleMaxSpeed;
            }
        }

        //Dificulty settings, set by the Property "GameDificulty"
        public GameDificulty GameDificulty
        {
            set
            {
                this.gameDificulty = value;
                switch (value)
                {
                    case GameDificulty.easy:
                        break;
                    case GameDificulty.medium:
                        this.gameSpeed++;
                        break;
                    case GameDificulty.hard:
                        this.gameSpeed++;
                        this.engineClockRatio -= 10;
                        break;
                }
                this.gameReadyToStart[1] = true;
            }
        }

        //Video settings in console mode, set by the Property "VideoModeSelector"
        public VMode VideoModeSelector
        {
            get
            {
                return this.videoModeSelector;
            }
            set
            {
                this.videoModeSelector = value;
                switch (value)
                {
                    case VMode.mode1:
                        this.videoMode = new int[]
                        {
                            16,
                            100,        //console width
                            16 * 3 + 1  //console high
                        };
                        this.midLevelFrogRow = 8;
                        this.safeRowIndexes = new int[] { 8, 15 };
                        this.laneRowIndexes = new int[] { 2, 3, 4, 5, 6, 7, 9, 10, 11, 12, 13, 14 };
                        break;
                    case VMode.mode2:
                        this.videoMode = new int[]
                        {
                            23,
                            150,        //console width
                            23 * 3 + 1  //console high
                        };
                        this.midLevelFrogRow = 15;
                        this.safeRowIndexes = new int[] { 8, 15, 22 };
                        this.laneRowIndexes = new int[] { 2, 3, 4, 5, 6, 7, 9, 10, 11, 12, 13, 14, 16, 17, 18, 19, 20, 21 };
                        break;
                }
                this.frogMaxRow = this.videoMode[0] - 1;
                this.initialFrogX = this.videoMode[1]/2;
                this.initialFrogRow = this.frogMaxRow;
                this.gameReadyToStart[0] = true;
            }
        }
        public int GameRows
        {
            get
            {
                return this.videoMode[0];
            }
        }
        public int ScreenWidth
        {
            get
            {
                return this.videoMode[1];
            }
        }
        public int ScreenHeight
        {
            get
            {
                return this.videoMode[2];
            }
        }
        public int[] SafeRowIndexes
        {
            get
            {
                return this.safeRowIndexes;
            }
        }
        public int[] LaneRowIndexes
        {
            get
            {
                return this.laneRowIndexes;
            }
        }

        //audio settings

        //performance monitor
        //high records + export/import to file + encription/decription

        public int FrogMaxX(int frogDisplayLength)
        {
            return this.ScreenWidth - 1 - frogDisplayLength;
        }
        public int VehicleMaxX(int vehicleDisplayLength)
        {
            return this.ScreenWidth - 1 - vehicleDisplayLength;
        }
    }
}