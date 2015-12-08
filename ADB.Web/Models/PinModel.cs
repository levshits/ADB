using System.ComponentModel.DataAnnotations;

namespace ADB.Web.Models
{
    public class PinModel
    {
        [Required]
        [StringLength(4)]
        [DataType(DataType.Password)]
        public string PinCode { get; set; }

        public int FailCount { get; set; }
    }
}