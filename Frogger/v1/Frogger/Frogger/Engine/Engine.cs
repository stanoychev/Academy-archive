using Frogger.Objects.Models;
using Frogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frogger.Updater;
using Frogger.Renderer.Enums;
using Frogger.Renderer.Models;
using Frogger.Renderer.RowCollection;

namespace Frogger.Engine
{
    public static class Engine
    {
        public static void Run()
        {
            //зарежда в RAM-та колекцията с обекти от тип Row RowID = [0..15] = 16 броя,
            //после в калкулатора им се променят стойностите във field-овете,
            //тук само се чете и визуализира
            Renderer.Renderer.InitializeRenderer();

            // - задава размерите на прозорчето;
            Console.SetWindowSize(GlobalConstants.screenWidth, GlobalConstants.screenHeight);
            //това не съм сигурен трябва ли не трябва ли, за сега не го включвам
            //Console.SetBufferSize(GlobalConstants.ScreenWidth, GlobalConstants.ScreenHeight);

            // - зареждане на жабата
            Swamp.Instance.IsAlive = true;

            // зарежда генератора на числа
            Random randNum = new Random();

            //that's for the Engine (in the Run method)
            Console.WriteLine(GlobalConstants.welcomeFrogger);
            Console.ReadKey();

            //сега палим мозъка
            Updater.Updater.StartGame();
        }

        public static int GenerateNum(Random randNum, int min, int max)
        {
            return randNum.Next(min, max);
        }

        //private static int VehicleMovement(int input)
        //{
        //    int result = input - GenerateNum(new Random(), 5, 15);
        //    if (input < 0)
        //    {
        //        result = 99;
        //    }
        //    else
        //    {
        //        return result;
        //    }
        //    return result;
        //}
    }
}
