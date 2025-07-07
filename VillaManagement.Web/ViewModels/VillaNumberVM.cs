using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using VillaManagement.Domain.Entities;

namespace VillaManagement.Web.ViewModels
{
    public class VillaNumberVM
    {
        public VillaNumber? VillaNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? VillaList { get; set; }

    }
}
