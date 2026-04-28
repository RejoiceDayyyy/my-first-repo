namespace FirstAspDemo.Models
{
    public class StudentCreateDto
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? ClassName { get; set; }
        //注意这里没有Id字段！
        // 这个DTO类用于接收前端传来的数据，Id由数据库自动生成，不需要前端提供
    }
}
