using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hdd.Domain.ViewModels
{
    public class TicketViewModel
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public string SelectedPriority { get; set; }
        public IEnumerable<SelectListItem> Priority { get; set; }

   
         public HttpPostedFileBase MyFile { get; set; }

        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

    }
}
