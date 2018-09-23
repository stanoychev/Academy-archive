using System;
using Utils;

namespace GameObjects
{
    public class LaneRow : BaseRow, ILaneRow
    {
        private readonly IVehicle vehicleOnTheRow;

        public LaneRow(IVehicle vehicle, RowID rowID, IFrog frog) : base(rowID, frog)
        {
            this.vehicleOnTheRow = vehicle;
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
                if ((int)base.RowID == base.Frog.Row)
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
                if (base.Frog.X >= this.VehicleOnTheRow.X + this.VehicleOnTheRow.ToString().Split('*')[0].Length)
                {
                    //Ако на реда има жаба и тя се намира след колата.
                    //FrogXmax <= 94 от това следва, че със сигурност цялата тази история няма да излезе от екрана.
                    //Изписва се: празно, кола, празно, жаба
                    return string.Format("{0}{1}{2}{3}*{0}{4}{2}{5}*{0}{6}{2}{7}",
                        new string(' ', this.VehicleOnTheRow.X),            //0, tova e taka
                        this.VehicleOnTheRow.ToString().Split('*')[0],      //1, tova e taka
                        new string(' ', base.Frog.X - this.VehicleOnTheRow.X - this.VehicleOnTheRow.ToString().Split('*')[0].Length),    //2, tova e taka
                        base.Frog.ToString().Split('*')[0],            //3, tova e taka
                        this.VehicleOnTheRow.ToString().Split('*')[1],      //4, tova e taka
                        base.Frog.ToString().Split('*')[1],            //5, tova e taka
                        this.VehicleOnTheRow.ToString().Split('*')[2],      //6, tova e taka
                        base.Frog.ToString().Split('*')[2]);           //7, tova e taka
                }
                else if (this.VehicleOnTheRow.X >= base.Frog.X + base.Frog.ToString().Split('*')[0].Length)
                {
                    if (this.VehicleOnTheRow.X + this.VehicleOnTheRow.ToString().Split('*')[0].Length < GlobalConstants.screenWidth)
                    {
                        //Ако на реда има жаба и тя се намира преди колата.
                        //Ако "празно, жаба, празно, кола" не излиза от екрана.
                        return string.Format("{0}{1}{2}{3}*{0}{4}{2}{5}*{0}{6}{2}{7}",
                            new string(' ', base.Frog.X),              //0
                            base.Frog.ToString().Split('*')[0],        //1
                            new string(' ', this.VehicleOnTheRow.X - base.Frog.X - base.Frog.ToString().Split('*')[0].Length),        //2
                            this.VehicleOnTheRow.ToString().Split('*')[0],  //3
                            base.Frog.ToString().Split('*')[1],        //4
                            this.VehicleOnTheRow.ToString().Split('*')[1],  //5
                            base.Frog.ToString().Split('*')[2],        //6
                            this.VehicleOnTheRow.ToString().Split('*')[2]); //7
                    }
                    else
                    {
                        //Ако на реда има жаба и тя се намира преди колата.
                        //Ако "празно, жаба, празно, кола" излиза от екрана.
                        return string.Format("{0}{1}{2}{3}*{0}{4}{2}{5}*{0}{6}{2}{7}",
                            new string(' ', base.Frog.X),                                                                                  //0
                            base.Frog.ToString().Split('*')[0],                                                                            //1
                            new string(' ', this.VehicleOnTheRow.X- base.Frog.X- base.Frog.ToString().Split('*')[0].Length),            //2
                            this.VehicleOnTheRow.ToString().Split('*')[0].Remove(GlobalConstants.screenWidth - this.VehicleOnTheRow.X - 1),     //3
                            base.Frog.ToString().Split('*')[1],                                                                            //4
                            this.VehicleOnTheRow.ToString().Split('*')[1].Remove(GlobalConstants.screenWidth - this.VehicleOnTheRow.X - 1),     //5
                            base.Frog.ToString().Split('*')[2],                                                                            //6
                            this.VehicleOnTheRow.ToString().Split('*')[2].Remove(GlobalConstants.screenWidth - this.VehicleOnTheRow.X - 1));    //7
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (base.Frog.X + 10 < GlobalConstants.screenWidth &&
                        this.VehicleOnTheRow.X + 13 < GlobalConstants.screenWidth &
                        Math.Min(this.VehicleOnTheRow.X, base.Frog.X) + 13 < GlobalConstants.screenWidth)
                    {
                        //Ако на реда има жаба и тя се е изджасала в колата.
                        //Ако са се изчеластрили преди края на реда.
                        if (this.VehicleOnTheRow.X <= base.Frog.X)
                        {
                            //Ако колата е преди жабата
                            Func<int, int, int> stamat =
                                (x, y) =>
                                {
                                    if (x <= y)
                                    {
                                        return base.Frog.FrogDisplayLength;
                                    }
                                    else
                                    {
                                        return this.VehicleOnTheRow.VehicleEndX - base.Frog.X + 1;
                                    }
                                };

                            return string.Format("{0}{1}{2}*{0}{3}{4}*{0}{5}{6}",
                            new string(' ', this.VehicleOnTheRow.X),
                            this.VehicleOnTheRow.ToString().Split('*')[0],
                            base.Frog.ToString().Split('*')[0].Remove(0, stamat(base.Frog.FrogEndX, this.VehicleOnTheRow.VehicleEndX)),
                            this.VehicleOnTheRow.ToString().Split('*')[1],
                            base.Frog.ToString().Split('*')[1].Remove(0, stamat(base.Frog.FrogEndX, this.VehicleOnTheRow.VehicleEndX)),
                            this.VehicleOnTheRow.ToString().Split('*')[2],
                            base.Frog.ToString().Split('*')[2].Remove(0, stamat(base.Frog.FrogEndX, this.VehicleOnTheRow.VehicleEndX)));
                        }
                        else
                        {
                            //Ако жабата е преди колата
                            return string.Format("{0}{1}{2}*{0}{3}{4}*{0}{5}{6}",
                            new string(' ', base.Frog.X),
                            base.Frog.ToString().Split('*')[0].Remove(base.Frog.FrogDisplayLength - 1 - (base.Frog.FrogEndX - this.VehicleOnTheRow.X), base.Frog.FrogEndX - this.VehicleOnTheRow.X + 1),
                            this.VehicleOnTheRow.ToString().Split('*')[0],
                            base.Frog.ToString().Split('*')[1].Remove(base.Frog.FrogDisplayLength - 1 - (base.Frog.FrogEndX - this.VehicleOnTheRow.X), base.Frog.FrogEndX - this.VehicleOnTheRow.X + 1),
                            this.VehicleOnTheRow.ToString().Split('*')[1],
                            base.Frog.ToString().Split('*')[2].Remove(base.Frog.FrogDisplayLength - 1 - (base.Frog.FrogEndX - this.VehicleOnTheRow.X), base.Frog.FrogEndX - this.VehicleOnTheRow.X + 1),
                            this.VehicleOnTheRow.ToString().Split('*')[2]);
                        }
                    }
                    else
                    {
                        //Ако на реда има жаба и тя се е изджасала в колата.
                        //Ако са се изчеластрили след края на реда.
                        return string.Format("{0}FrogX = {1}*{2}VehicleX = {3}*{4} Crashed",
                        new string(' ', 86),
                        base.Frog.X,
                        new string(' ', 86),
                        this.VehicleOnTheRow.X,
                        new string(' ', 86));
                    }
                }
            }
            else
            {
                if (this.VehicleOnTheRow.X < GlobalConstants.screenWidth - this.VehicleOnTheRow.ToString().Split('*')[0].Length)
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
                        this.VehicleOnTheRow.ToString().Split('*')[0].Remove(GlobalConstants.screenWidth - this.VehicleOnTheRow.X - 1),
                        this.VehicleOnTheRow.ToString().Split('*')[1].Remove(GlobalConstants.screenWidth - this.VehicleOnTheRow.X - 1),
                        this.VehicleOnTheRow.ToString().Split('*')[2].Remove(GlobalConstants.screenWidth - this.VehicleOnTheRow.X - 1));
                }
            }
        }
    }
}
