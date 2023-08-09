using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace AuthProject.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required,DataType(DataType.Text)]
        public String Address { get; set; }


    }
}
