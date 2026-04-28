using FirstAspDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAspDemo
{
    // 数据库上下文，管理实体与数据库的映射关系
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _config;
        // 构造函数注入配置对象
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }
        // 数据库连接配置
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            // 连接本地 SQL Server
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                    );
            }
        }

        // 学生表
        // 学生实体集合，映射数据库Students表
        public DbSet<Student> Students { get; set; }
    }
}