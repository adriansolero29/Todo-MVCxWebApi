using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Todo.Persistence.Entities;

namespace Todo.Persistence.Data;

public class TodoDbContext : IdentityDbContext<UserEntity>
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
        
    }

    public DbSet<MemberEntity> Members { get; set; }
    public DbSet<SubTaskInfoEntity> SubTasks { get; set; }
    public DbSet<TaskInfoEntity> Tasks { get; set; }
}
