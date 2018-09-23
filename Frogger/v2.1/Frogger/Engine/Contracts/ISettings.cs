using GameObjects;

namespace Engine
{
    public interface ISettings
    {
        //game fine settings and initial conditions
        bool TestConditions { set; }
        bool EngineDemand { set; }
        int EngineClockRatio { get; set; }
        int GameSpeed { get; set; }
        int GameScore { get; set; }
        int GameSpeedMin { get; }
        int GameSpeedMax { get; }
        int InitialGameScore { get; }
        bool GameReadyToStart { get; }

        //Screens
        string WelcomeFrogger { get; }
        string WellDoneFrogger { get; }
        string GameOverFrogger { get; }

        //Frog settings
        int FrogMinX { get; }
        int FrogMinRow { get; }
        int FrogMaxRow { get; }
        int InitialFrogX { get; }
        int InitialFrogRow { get; }
        int MidLevelFrogRow { get; }
        int InitialFrogLives { get; }
        int InitialFrogLevel { get; }
        int MaxFrogLevel { get; }
        int FrogXIncrement { get; }

        //Vehicle settings
        int VehicleMinX { get; }
        //int VehicleMaxX { get; }
        //public int VehicleMinRow { get; }
        //public int VehicleMaxRow { get; }
        int VehicleFillMultiplierMin { get; }
        int VehicleFillMultiplierMax { get; }
        int VehicleMinSpeed { get; }
        int VehicleMaxSpeed { get; }

        //Dificulty settings, set by the Property "GameDificulty
        GameDificulty GameDificulty { set; }

        //Video settings in console mode, set by the Property "VideoModeSelector"
        VMode VideoModeSelector { get; set; }
        int GameRows { get; }
        int ScreenWidth { get; }
        int ScreenHeight { get; }
        int[] SafeRowIndexes { get; }
        int[] LaneRowIndexes { get; }

        int FrogMaxX(int frogDisplayLength);
        int VehicleMaxX(int vehicleDisplayLength);
    }
}
