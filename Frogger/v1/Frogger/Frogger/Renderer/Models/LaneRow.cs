using Frogger.Objects.Models;
using Frogger.Renderer.Abstract;
using Frogger.Renderer.Contracts;
using Frogger.Renderer.Enums;
using Frogger.Utils;
using System;

namespace Frogger.Renderer.Models
{
    public class LaneRow : BaseRow, ILaneRow
    {
        //няма да е VehichleX, защото нямам само едно Vehicle => трябва да ги държа или в колекция
        //или по-интелигентно във всеки LaneRow да има инстанция Vehicle, но по една, за това я правя readonly

        private readonly Vehicle vehicleOnTheRow;

        public LaneRow(RowID initialRowID) : base(initialRowID)
        {
            this.vehicleOnTheRow = new Vehicle();
            //default-ен конструктор, ползвам го при инициализацията на модела
            //във всеки LaneRow има по една количка, където да и се пазят персонално стойностите
        }

        public IVehicle VehicleOnTheRow
        {
            get
            {
                return this.vehicleOnTheRow;
            }
        }

        public override string ToString()
        {
            if (base.HasFrog)
            {
                if (Swamp.Instance.X >= this.VehicleOnTheRow.X + this.VehicleOnTheRow.ToString().Split('*')[0].Length)
                {
                    //Ако на реда има жаба и тя се намира след колата.
                    //FrogXmax <= 94 от това следва, че със сигурност цялата тази история няма да излезе от екрана.
                    //Изписва се: празно, кола, празно, жаба
                    return string.Format("{0}{1}{2}{3}*{0}{4}{2}{5}*{0}{6}{2}{7}",
                        new string(' ', this.VehicleOnTheRow.X),            //0, tova e taka
                        this.VehicleOnTheRow.ToString().Split('*')[0],      //1, tova e taka
                        new string(' ', Swamp.Instance.X - this.VehicleOnTheRow.X - this.VehicleOnTheRow.ToString().Split('*')[0].Length),    //2, tova e taka
                        Swamp.Instance.ToString().Split('*')[0],            //3, tova e taka
                        this.VehicleOnTheRow.ToString().Split('*')[1],      //4, tova e taka
                        Swamp.Instance.ToString().Split('*')[1],            //5, tova e taka
                        this.VehicleOnTheRow.ToString().Split('*')[2],      //6, tova e taka
                        Swamp.Instance.ToString().Split('*')[2]);           //7, tova e taka
                }
                else if (this.VehicleOnTheRow.X >= Swamp.Instance.X + Swamp.Instance.ToString().Split('*')[0].Length)
                {
                    if (this.VehicleOnTheRow.X + this.VehicleOnTheRow.ToString().Split('*')[0].Length < GlobalConstants.screenWidth)
                    {
                        //Ако на реда има жаба и тя се намира преди колата.
                        //Ако "празно, жаба, празно, кола" не излиза от екрана.
                        return string.Format("{0}{1}{2}{3}*{0}{4}{2}{5}*{0}{6}{2}{7}",
                            new string(' ', Swamp.Instance.X),              //0
                            Swamp.Instance.ToString().Split('*')[0],        //1
                            new string(' ', this.VehicleOnTheRow.X - Swamp.Instance.X - Swamp.Instance.ToString().Split('*')[0].Length),        //2
                            this.VehicleOnTheRow.ToString().Split('*')[0],  //3
                            Swamp.Instance.ToString().Split('*')[1],        //4
                            this.VehicleOnTheRow.ToString().Split('*')[1],  //5
                            Swamp.Instance.ToString().Split('*')[2],        //6
                            this.VehicleOnTheRow.ToString().Split('*')[2]); //7
                    }
                    else
                    {
                        //Ако на реда има жаба и тя се намира преди колата.
                        //Ако "празно, жаба, празно, кола" излиза от екрана.
                        return string.Format("{0}{1}{2}{3}*{0}{4}{2}{5}*{0}{6}{2}{7}",
                            new string(' ', Swamp.Instance.X),                                                                                  //0
                            Swamp.Instance.ToString().Split('*')[0],                                                                            //1
                            new string(' ', this.VehicleOnTheRow.X-Swamp.Instance.X-Swamp.Instance.ToString().Split('*')[0].Length),            //2
                            this.VehicleOnTheRow.ToString().Split('*')[0].Remove(GlobalConstants.screenWidth - this.VehicleOnTheRow.X - 1),     //3
                            Swamp.Instance.ToString().Split('*')[1],                                                                            //4
                            this.VehicleOnTheRow.ToString().Split('*')[1].Remove(GlobalConstants.screenWidth - this.VehicleOnTheRow.X - 1),     //5
                            Swamp.Instance.ToString().Split('*')[2],                                                                            //6
                            this.VehicleOnTheRow.ToString().Split('*')[2].Remove(GlobalConstants.screenWidth - this.VehicleOnTheRow.X - 1));    //7
                    }
                }
                else
                {
                    if (Swamp.Instance.X + 10 < GlobalConstants.screenWidth &&
                        this.VehicleOnTheRow.X + 13 < GlobalConstants.screenWidth &
                        Math.Min(this.VehicleOnTheRow.X, Swamp.Instance.X) + 13 < GlobalConstants.screenWidth)
                    {
                        //Ако на реда има жаба и тя се е изджасала в колата.
                        //Ако са се изчеластрили преди края на реда.
                        return string.Format("{0}FrogX = {1}*{2}VehicleX = {3}*{4} => Crashed", //n==13
                        new string(' ', Swamp.Instance.X),
                        Swamp.Instance.X,
                        new string(' ', this.VehicleOnTheRow.X),
                        this.VehicleOnTheRow.X,
                        new string(' ', Math.Min(this.VehicleOnTheRow.X, Swamp.Instance.X)));
                    }
                    else
                    {
                        //Ако на реда има жаба и тя се е изджасала в колата.
                        //Ако са се изчеластрили след края на реда.
                        return string.Format("{0}FrogX = {1}*{2}VehicleX = {3}*{4} => Crashed", //n==13
                        new string(' ', 86),
                        Swamp.Instance.X,
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
