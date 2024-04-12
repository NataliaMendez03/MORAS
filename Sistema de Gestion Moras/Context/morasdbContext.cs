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
        }
        public DbSet<Tracking> Tracking { get; set; }
    }
}
