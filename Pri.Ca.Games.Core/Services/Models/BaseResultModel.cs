using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Ca.Games.Core.Services.Models
{
    public class BaseResultModel
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<ValidationResult> ValidationErrors { get; set; }
    }
}
