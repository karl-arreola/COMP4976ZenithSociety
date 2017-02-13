using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenithDataLib.Models.CutomValidations;

namespace ZenithDataLib.Models
{
    [MetadataType(typeof(EventMetadata))]
    public partial class Event { }

    public class EventMetadata
    {
        [Required]
        [DateToValidation(ErrorMessage = "DateTo must be later than DateFrom")]
        public DateTime DateTo { get; set; }
    }
}
