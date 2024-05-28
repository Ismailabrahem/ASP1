using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<SubscriberEntity> Subscribers { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<ContactRequestEntity> ContactRequests { get; set; }
    public DbSet<CourseDetailEntity> CourseDetails { get; set; }
    public DbSet<ProgramDetailEntity> ProgramDetails { get; set; }
}

