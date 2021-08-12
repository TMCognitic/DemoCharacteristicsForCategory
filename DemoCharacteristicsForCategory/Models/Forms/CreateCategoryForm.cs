using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCharacteristicsForCategory.Models.Forms
{
    public class CreateCategoryForm
    {
        [Required]        
        public string Name { get; set; }

        public IEnumerable<string> Characteristics { get; set; }
    }
}
