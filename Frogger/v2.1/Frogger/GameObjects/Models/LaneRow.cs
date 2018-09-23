using Engine;
using System;

namespace GameObjects
{
    public class LaneRow : ILaneRow
    {
        private readonly IVehicle vehicleOnTheRow;
        private readonly IFrog frog;
        private readonly int rowID;
        private readonly ISettings settings;

        public LaneRow(IVehicle vehicle, IFrog frog, int rowID, ISettings settings)
        {
            this.vehicleOnTheRow = vehicle;
            this.frog = frog;
            this.rowID = rowID;
            this.settings = settings;
        }

        public IVehicle VehicleOnTheRow
        {
            get
            {
                return this.vehicleOnTheRow;
            }
        }

        private bool HasFrog
        {
            get
            {
                if (this.rowID == this.frog.Row)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override string ToString()
        {
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (this.HasFrog)
            {
                if (this.frog.X >= this.VehicleOnTheRow.X + this.VehicleOnTheRow.ToString().Split('*')[0].Length)
                {
                    //Ако на реда има жаба и тя се намира след колата.
                    //FrogXmax <= 94 от това следва, че със сигурност цялата тази история няма да излезе от екрана.
                    //Изписва се: празно, кола, празно, жаба
                    return string.Format("{0}{1}{2}{3}*{0}{4}{2}{5}*{0}{6}{2}{7}",
                        new string(' ', this.VehicleOnTheRow.X),            //0, tova e taka
                        this.VehicleOnTheRow.ToString().Split('*')[0],      //1, tova e taka
                        new string(' ', this.frog.X - this.VehicleOnTheRow.X - this.VehicleOnTheRow.ToString().Split('*')[0].Length),    //2, tova e taka
                        this.frog.ToString().Split('*')[0],            //3, tova e taka
                        this.VehicleOnTheRow.ToString().Split('*')[1],      //4, tova e taka
                        this.frog.ToString().Split('*')[1],            //5, tova e taka
                        this.VehicleOnTheRow.ToString().Split('*')[2],      //6, tova e taka
                        this.frog.ToString().Split('*')[2]);           //7, tova e taka
                }
                else if (this.VehicleOnTheRow.X >= this.frog.X + this.frog.ToString().Split('*')[0].Length)
                {
                    if (this.VehicleOnTheRow.X + this.VehicleOnTheRow.ToString().Split('*')[0].Length < this.settings.ScreenWidth)
                    {
                        //Ако на реда има жаба и тя се намира преди колата.
                        //Ако "празно, жаба, празно, кола" не излиза от екрана.
                        return string.Format("{0}{1}{2}{3}*{0}{4}{2}{5}*{0}{6}{2}{7}",
                            new string(' ', this.frog.X),              //0
                            this.frog.ToString().Split('*')[0],        //1
                            new string(' ', this.VehicleOnTheRow.X - this.frog.X - this.frog.ToString().Split('*')[0].Length),        //2
                            this.VehicleOnTheRow.ToString().Split('*')[0],  //3
                            this.frog.ToString().Split('*')[1],        //4
                            this.VehicleOnTheRow.ToString().Split('*')[1],  //5
                            this.frog.ToString().Split('*')[2],        //6
                            this.VehicleOnTheRow.ToString().Split('*')[2]); //7
                    }
                    else
                    {
                        //Ако на реда има жаба и тя се намира преди колата.
                        //Ако "празно, жаба, празно, кола" излиза от екрана.
                        return string.Format("{0}{1}{2}{3}*{0}{4}{2}{5}*{0}{6}{2}{7}",
                            new string(' ', this.frog.X),                                                                                  //0
                            this.frog.ToString().Split('*')[0],                                                                            //1
                            new string(' ', this.VehicleOnTheRow.X- this.frog.X- this.frog.ToString().Split('*')[0].Length),            //2
                            this.VehicleOnTheRow.ToString().Split('*')[0].Remove(this.settings.ScreenWidth - this.VehicleOnTheRow.X - 1),     //3
                            this.frog.ToString().Split('*')[1],                                                                            //4
                            this.VehicleOnTheRow.ToString().Split('*')[1].Remove(this.settings.ScreenWidth - this.VehicleOnTheRow.X - 1),     //5
                            this.frog.ToString().Split('*')[2],                                                                            //6
                            this.VehicleOnTheRow.ToString().Split('*')[2].Remove(this.settings.ScreenWidth - this.VehicleOnTheRow.X - 1));    //7
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (this.frog.X + 10 < this.settings.ScreenWidth &&
                        this.VehicleOnTheRow.X + 13 < this.settings.ScreenWidth &
                        Math.Min(this.VehicleOnTheRow.X, this.frog.X) + 13 < this.settings.ScreenWidth)
                    {
                        //Ако на реда има жаба и тя се е изджасала в колата.
                        //Ако са се изчеластрили преди края на реда.
                        if (this.VehicleOnTheRow.X <= this.frog.X)
                        {
                            //Ако колата е преди жабата
                            Func<int, int, int> stamat =
                                (x, y) =>
                                {
                                    if (x <= y)
                                    {
                                        return this.frog.FrogDisplayLength;
                                    }
                                    else
                                    {
                                        return this.VehicleOnTheRow.VehicleEndX - this.frog.X + 1;
                                    }
                                };

                            return string.Format("{0}{1}{2}*{0}{3}{4}*{0}{5}{6}",
                            new string(' ', this.VehicleOnTheRow.X),
                            this.VehicleOnTheRow.ToString().Split('*')[0],
                            this.frog.ToString().Split('*')[0].Remove(0, stamat(this.frog.FrogEndX, this.VehicleOnTheRow.VehicleEndX)),
                            this.VehicleOnTheRow.ToString().Split('*')[1],
                            this.frog.ToString().Split('*')[1].Remove(0, stamat(this.frog.FrogEndX, this.VehicleOnTheRow.VehicleEndX)),
                            this.VehicleOnTheRow.ToString().Split('*')[2],
                            this.frog.ToString().Split('*')[2].Remove(0, stamat(this.frog.FrogEndX, this.VehicleOnTheRow.VehicleEndX)));
                        }
                        else
                        {
                            //Ако жабата е преди колата
                            return string.Format("{0}{1}{2}*{0}{3}{4}*{0}{5}{6}",
                            new string(' ', this.frog.X),
                            this.frog.ToString().Split('*')[0].Remove(this.frog.FrogDisplayLength - 1 - (this.frog.FrogEndX - this.VehicleOnTheRow.X), this.frog.FrogEndX - this.VehicleOnTheRow.X + 1),
                            this.VehicleOnTheRow.ToString().Split('*')[0],
                            this.frog.ToString().Split('*')[1].Remove(this.frog.FrogDisplayLength - 1 - (this.frog.FrogEndX - this.VehicleOnTheRow.X), this.frog.FrogEndX - this.VehicleOnTheRow.X + 1),
                            this.VehicleOnTheRow.ToString().Split('*')[1],
                            this.frog.ToString().Split('*')[2].Remove(this.frog.FrogDisplayLength - 1 - (this.frog.FrogEndX - this.VehicleOnTheRow.X), this.frog.FrogEndX - this.VehicleOnTheRow.X + 1),
                            this.VehicleOnTheRow.ToString().Split('*')[2]);
                        }
                    }
                    else
                    {
                        //Ако на реда има жаба и тя се е изджасала в колата.
                        //Ако са се изчеластрили след края на реда.
                        return string.Format("{0}FrogX = {1}*{2}VehicleX = {3}*{4} Crashed",
                        new string(' ', 86),
                        this.frog.X,
                        new string(' ', 86),
                        this.VehicleOnTheRow.X,
                        new string(' ', 86));
                    }
                }
            }
            else
            {
                if (this.VehicleOnTheRow.X < this.settings.ScreenWidth - this.VehicleOnTheRow.ToString().Split('*')[0].Length)
                {
                    //Ако на реда няма жаба.
                    //Ако колата е преди края на екрана.
                    return string.Format("{0}{1}*{0}{2}*{0}{3}",
                        new string(' ', this.VehicleOnTheRow.X),
                        this.VehicleOnTheRow.ToString().Split('*')[0],
                        this.VehicleOnTheRow.ToString().Split('*')[1],
                        this.VehicleOnTheRow.ToString().Split('*')[2]);
                }
                else
                {
                    //Ако на реда няма жаба.
                    //Ако колата е след края на екрана.
                    return string.Format("{0}{1}*{0}{2}*{0}{3}",
                        new string(' ', this.VehicleOnTheRow.X),
                        this.VehicleOnTheRow.ToString().Split('*')[0].Remove(this.settings.ScreenWidth - this.VehicleOnTheRow.X - 1),
                        this.VehicleOnTheRow.ToString().Split('*')[1].Remove(this.settings.ScreenWidth - this.VehicleOnTheRow.X - 1),
                        this.VehicleOnTheRow.ToString().Split('*')[2].Remove(this.settings.ScreenWidth - this.VehicleOnTheRow.X - 1));
                }
            }
        }
    }
}
