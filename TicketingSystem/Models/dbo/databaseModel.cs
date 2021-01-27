namespace TicketingSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class databaseModel : DbContext
    {
        public databaseModel()
            : base("name=databaseModel")
        {
        }

        public virtual DbSet<addresses> addresses { get; set; }
        public virtual DbSet<countries> countries { get; set; }
        public virtual DbSet<customer_addresses> customer_addresses { get; set; }
        public virtual DbSet<customers> customers { get; set; }
        public virtual DbSet<salutations> salutations { get; set; }
        public virtual DbSet<settings> settings { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        public virtual DbSet<ticket> ticket { get; set; }
        public virtual DbSet<ticket_categories> ticket_categories { get; set; }
        public virtual DbSet<ticket_priorities> ticket_priorities { get; set; }
        public virtual DbSet<ticket_statuses> ticket_statuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<addresses>()
                .Property(e => e.streetname)
                .IsUnicode(false);

            modelBuilder.Entity<addresses>()
                .Property(e => e.cityname)
                .IsUnicode(false);

            modelBuilder.Entity<addresses>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<addresses>()
                .HasMany(e => e.customer_addresses)
                .WithRequired(e => e.addresses)
                .HasForeignKey(e => e.aid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<addresses>()
                .HasMany(e => e.staff)
                .WithOptional(e => e.addresses)
                .HasForeignKey(e => e.address);

            modelBuilder.Entity<countries>()
                .Property(e => e.iso)
                .IsUnicode(false);

            modelBuilder.Entity<countries>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<countries>()
                .HasMany(e => e.addresses)
                .WithOptional(e => e.countries)
                .HasForeignKey(e => e.country);

            modelBuilder.Entity<customers>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.last_login)
                .HasPrecision(0);

            modelBuilder.Entity<customers>()
                .Property(e => e.created_at)
                .HasPrecision(0);

            modelBuilder.Entity<customers>()
                .HasMany(e => e.customer_addresses)
                .WithRequired(e => e.customers)
                .HasForeignKey(e => e.cid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customers>()
                .HasMany(e => e.ticket)
                .WithOptional(e => e.customers)
                .HasForeignKey(e => e.customer_number);

            modelBuilder.Entity<salutations>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<salutations>()
                .HasMany(e => e.customers)
                .WithRequired(e => e.salutations)
                .HasForeignKey(e => e.salutation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<salutations>()
                .HasMany(e => e.staff)
                .WithRequired(e => e.salutations)
                .HasForeignKey(e => e.salutation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<settings>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<settings>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.username)
                .IsUnicode(false);


            modelBuilder.Entity<staff>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.last_login)
                .HasPrecision(0);

            modelBuilder.Entity<staff>()
                .Property(e => e.created_at)
                .HasPrecision(0);

            modelBuilder.Entity<staff>()
                .Property(e => e.absence_begin)
                .HasPrecision(0);

            modelBuilder.Entity<staff>()
                .Property(e => e.absence_end)
                .HasPrecision(0);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.ticket)
                .WithOptional(e => e.staff)
                .HasForeignKey(e => e.agent);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.ticket_categories)
                .WithMany(e => e.staff)
                .Map(m => m.ToTable("ticket_categories_staff").MapLeftKey("sid").MapRightKey("tcid"));

            modelBuilder.Entity<ticket>()
                .Property(e => e.subject)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.ticket_content)
                .IsUnicode(false);

            modelBuilder.Entity<ticket_categories>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ticket_categories>()
                .HasMany(e => e.ticket)
                .WithOptional(e => e.ticket_categories)
                .HasForeignKey(e => e.category);

            modelBuilder.Entity<ticket_priorities>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ticket_priorities>()
                .HasMany(e => e.ticket)
                .WithOptional(e => e.ticket_priorities)
                .HasForeignKey(e => e.priority);

            modelBuilder.Entity<ticket_statuses>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ticket_statuses>()
                .HasMany(e => e.ticket)
                .WithOptional(e => e.ticket_statuses)
                .HasForeignKey(e => e.status);
        }

        public System.Data.Entity.DbSet<TicketingSystem.Models.CreateTicket> TicketCreations { get; set; }

        public System.Data.Entity.DbSet<TicketingSystem.Models.Suche> Suches { get; set; }
    }
}
