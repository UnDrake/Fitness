using FitnessArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessArchitecture.DAL
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
		{
			Database.EnsureCreated();
		}

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
		public DbSet<ProductToList> AddedProducts { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
		public DbSet<ExerciseToList> AddedExercises { get; set; }
		public DbSet<Sleep> Sleeps { get; set; }
		public DbSet<ProductList> ProductLists { get; set; }
		public DbSet<ExerciseList> ExerciseLists { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Account>(builder =>
			{
				builder.ToTable("Accounts").HasKey(a => a.accountID);

				builder.Property(a => a.accountID).ValueGeneratedOnAdd();
				builder.Property(a => a.accountEmail).IsRequired();
				builder.Property(a => a.accountPassword).IsRequired();
					
				builder.HasOne(a => a.user).WithOne(a => a.account).HasPrincipalKey<Account>(a => a.accountID)
				.OnDelete(DeleteBehavior.Cascade);
				builder.HasOne(a => a.sleep).WithOne(a => a.account).HasPrincipalKey<Account>(a => a.accountID)
				.OnDelete(DeleteBehavior.Cascade);
				builder.HasOne(a => a.productList).WithOne(a => a.account).HasPrincipalKey<Account>(a => a.accountID)
				.OnDelete(DeleteBehavior.Cascade);
				builder.HasOne(a => a.exerciseList).WithOne(a => a.account).HasPrincipalKey<Account>(a => a.accountID)
				.OnDelete(DeleteBehavior.Cascade);
			});


			modelBuilder.Entity<User>(builder =>
			{
				builder.ToTable("Users").HasKey(u => u.userID);

				builder.Property(u => u.userID).ValueGeneratedOnAdd();
			});


			modelBuilder.Entity<Exercise>(builder =>
			{
				builder.ToTable("Exercises").HasKey(e => e.exerciseID);
				//builder.Property(e => e.exerciseID).ValueGeneratedOnAdd();
			});


			modelBuilder.Entity<Product>(builder =>
			{
				builder.ToTable("Products").HasKey(p => p.productID);
                //builder.Property(p => p.productID).ValueGeneratedOnAdd();
            });


			modelBuilder.Entity<Sleep>(builder =>
			{
				builder.ToTable("Sleeps").HasKey(s => s.sleepID);
            });


			modelBuilder.Entity<ExerciseList>(builder =>
			{
				builder.ToTable("ExerciseLists").HasKey(el => el.exerciseListID);
			});


			modelBuilder.Entity<ProductList>(builder =>
			{
				builder.ToTable("ProductLists").HasKey(pl => pl.productListID);
			});


			modelBuilder.Entity<ExerciseToList>(builder =>
			{
				builder.ToTable("AddedExercises").HasKey(ae => ae.addExerciseID);
				builder.HasOne(el => el.exerciseList).WithMany(ae => ae.addedExercises)
				.HasForeignKey(k => k.exerciseListID);
			});


			modelBuilder.Entity<ProductToList>(builder =>
			{
				builder.ToTable("AddedProducts").HasKey(ap => ap.addProductID);
				builder.HasOne(pl => pl.productList).WithMany(ap => ap.addedProducts)
				.HasForeignKey(k => k.productListID);
			});
		}
	}
}