using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensei.Data.Models.Intermediate
{
    public class RegisterNewSensorModel
    {
        [Display(Name = "Specify sensor`s name: ")]
        public string Name { get; set; } //usera si kry6tava senzora

        [Display(Name = "Supported sensors: ")]
        public string Tag { get; set; }

        [Display(Name= "Specify sensor description:")]
        public string DescriptionGivenByTheUser { get; set; } //da se zapaza i v bazata

        public string CreatedByUsername { get; set; }

        public bool IsNumericValueType { get; set; } //default false

        [Display(Name = "Sensor URL: ")]
        public string Url { get; set; } //samo se pokazwa na user-a bez vyzmojnost posledniq da go promenq

        [Display(Name = "Specify polling interval in seconds (integer, divisible by 5): ")]
        public int PollingInterval { get; set; }

        [Display(Name = "Specify measurement type (type converter coming soon): ")]
        public string MeasurementType { get; set; } //tva kato bonus, trqbva convert-ira6ta sistema na merni edinici

        [Display(Name = "Would the sensor be publicly accessable? ")]
        public bool IsPublic { get; set; } //default false

        [Display(Name = "Operation Range: ")]
        public string OperatingRange { get; set; }

        [Display(Name = "Specify sensor min value: ")]
        public int MinValue { get; set; } //syobrazeni s description-a na senzora

        [Display(Name = "Specify sensor max value: ")]
        public int MaxValue { get; set; } //syobrazeni s description-a na senzora
        
        public DateTime AddedOn { get; set; }
    }
}
