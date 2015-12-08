using System;
using System.ComponentModel.DataAnnotations;

namespace ADB.Web.Models
{
    public class CloseDayModel
    {
        [Required]
        [UIHint("Date")]
        public DateTime DayToClose { get; set; } = DateTime.Now;
    }
}