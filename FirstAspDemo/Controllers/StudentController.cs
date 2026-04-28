using FirstAspDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // 用构造函数注入DbContext，而不是自己new
        private readonly AppDbContext _db;

        public string? Name { get; private set; }
        public int Age { get; private set; }
        public string? ClassName { get; private set; }

        public StudentController(AppDbContext db)
        {
            _db = db;
        }

        // 其他方法保持不变
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _db.Students.ToList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _db.Students.Find(id);
            if (student == null) return NotFound("找不到学生");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Add([FromBody] StudentCreateDto studentDto)
        {
            try
            {
                //将DTO转换为实体对象
                var student = new Student();
                {
                    Name = studentDto.Name;
                    Age = studentDto.Age;
                    ClassName = studentDto.ClassName;
                    //Id不需要设置，EF会自动生成
                    };
                //student.Id = 0; // 确保Id为0，EF会自动生成
                _db.Students.Add(student);
                _db.SaveChanges();
                return Ok("添加成功，Id=" + student.Id); // 打印自增后的Id
            }
            catch (Exception ex)
            {
                return BadRequest("添加失败：" + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Student student)
        {
            _db.Students.Update(student);
            _db.SaveChanges();
            return Ok("修改成功");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _db.Students.Find(id);
            if (student == null) return NotFound("找不到学生");

            _db.Students.Remove(student);
            _db.SaveChanges();
            return Ok("删除成功");
        }
    }
}