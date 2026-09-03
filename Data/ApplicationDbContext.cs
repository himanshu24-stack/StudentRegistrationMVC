namespace StudentRegistrationMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Student entity
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);
                entity.Property(e => e.StudentId).ValueGeneratedOnAdd();
                entity.Property(e => e.Percentage).HasPrecision(5, 2);
                entity.Property(e => e.RegistrationDate).HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
