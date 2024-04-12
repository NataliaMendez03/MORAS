namespace Sistema_de_Gestion_Moras.Context
{
    public class morasdbContext: DbContext
    {
        ///HOLA :D
        public morasdbContext(DbContextOptions<UserdbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tracking>()
                .HasKey(e => e.IdTracking);
            //HasNoKey()
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;

            }
        }
        public DbSet<Tracking> Tracking { get; set; }
    }
}
