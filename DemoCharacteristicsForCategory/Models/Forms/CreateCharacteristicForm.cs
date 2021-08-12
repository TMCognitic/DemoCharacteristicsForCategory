using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCharacteristicsForCategory.Models.Forms
{
    public class CreateCharacteristicForm
    {
        [Required]
        public string Name { get; set; }
    }
}
