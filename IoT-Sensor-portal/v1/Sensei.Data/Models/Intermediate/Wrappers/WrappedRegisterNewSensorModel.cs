using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensei.Data.Models.Intermediate.Wrappers
{
    public class WrappedRegisterNewSensorModel
    {
        //taq tapnq q pravq, za6toto vyv view modela iskam da vkaram edin model i da izkaram drug, poneje ne dava gi wrap-vam v edin obekt

        public List<FetchedSensorModels> AvailableSensors { get; set; }

        public RegisterNewSensorModel RegisterNewSensorModel { get; set; }
    }
}
