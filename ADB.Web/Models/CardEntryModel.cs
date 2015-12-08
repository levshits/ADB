using System.ComponentModel.DataAnnotations;

namespace ADB.Web.Models
{
    public class CardEntryModel
    {
        [Required]
        [StringLength(16)]
        public string Number { get; set; } 
    }
}