using Sensei.Database.Models;
using Sensei.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensei.Data.Models.Intermediate.Wrappers
{
    public class RegisterNewSensorViewModel
    {
        public IEnumerable<SensorReadInData> AvailableSensors { get; set; }

        public Sensor Sensor { get; set; }
        
        //public LastValue LastValue { get; set; }

        [Display(Name = "Supported sensors: ")]
        public string Tag { get; set; }
    }

    public class ViewOwnSensorsModel
    {
        //- - - - - - - for HTTP GET - - - - - - -

        public IEnumerable<SensorDisplayData> OwnSensors { get; set; }
        
        //IEnumerable<{username}>
        public IEnumerable<string> RegisteredUsers { get; set; }

        //IDictionary<{SensorId}, IEnumerable<{username}>>
        public IDictionary<int, IEnumerable<string>> MySensorsAndWithWhoAreTheySharedWith { get; set; }
        
        public IEnumerable<SensorDisplayData> ListSharedWithMeSensors { get; set; }

        //- - - - - - - for HTTP POST - - - - - - -

        //IDictionary<{SensorId}, IEnumerable<{username}>>
        public IDictionary<int, IEnumerable<string>> UsersToShareMySensorsWith { get; set; }
    }
}
