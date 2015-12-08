using System;
using System.ComponentModel.DataAnnotations;
using ADB.Web.Attributes;

namespace ADB.Web.Models
{
    public class CloseDayModel
    {
        [Required]
        [LocalisedName()]
        [DataType(DataType.Date)]
        public DateTime DayToClose { get; set; } = DateTime.Now;
    }
}