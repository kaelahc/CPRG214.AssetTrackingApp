using System.ComponentModel.DataAnnotations;

namespace CPRG214.Assets.AssetTracking.Models
{
    public class AssetTypeViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Asset Type")]
        [Required] public string Name { get; set; }
    }
}
