using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AuthProject.Models
{
    public class ImageUpload
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
