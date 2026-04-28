using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAspDemo.Models
{

using System.ComponentModel.DataAnnotations;

public class Student
    {
        [Key] // 标记为主键
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 标记为自增列
        public int Id { get; set; }

        public string? Name { get; set; }
        public int Age { get; set; }
        public string? ClassName { get; set; }
    }
}
