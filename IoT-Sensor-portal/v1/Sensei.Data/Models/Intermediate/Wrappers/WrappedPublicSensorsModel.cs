using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensei.Data.Models.Intermediate.Wrappers
{
    public class WrappedPublicSensorsModel
    {
        public List<PublicSensorInformation> PublicSensorInformation { get; set; }

        //ideqta e, dokato se generira gorniq model i se dostypva bazata samo za publi4nite senzori
        //dokato se izvli4at gornite senzori sys sy6tata tranzakciq da se izvle4e i spisyk s vida na publi4nite senzori

        //cqlata tazi hamalogiq mi trqbva kogato usera kaje "list all public sensors" da ne hodq do API-to i da svalqm 
        //value na vsi4ki 12/12 wyzmojni senzori naprimer, ami samo na 8/12 naprimer, toest samo za koito e nujno

        //Dictionary<sensorId, SensorCurrentValues>, kydeto sensor value se popylva v kontrolera i ne me vylnuva
        public Dictionary<string, SensorCurrentValues> PublicSensorIDs { get; set; }
    }
}
