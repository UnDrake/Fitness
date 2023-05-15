using FitnessArchitecture.DAL;
using FitnessArchitecture.DAL.Interfaces;
using FitnessArchitecture.DAL.Repositories;
using FitnessArchitecture.Domain.Models;
using FitnessArchitecture.Service.Implementations;
using FitnessArchitecture.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace FitnessArchitecture
{
	public class Startup
	{
		private IConfigurationRoot _confString;

		public Startup(IHostEnvironment hostEnv)
		{
			_confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
			services.AddAuthorization();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddScoped<IBaseRepository<User>, UserRepository>();
			services.AddScoped<IBaseRepository<Account>, AccountRepository>();
			services.AddScoped<IBaseRepository<ExerciseList>, ExerciseListRepository>();
			services.AddScoped<IBaseRepository<ProductList>, ProductListRepository>();
			services.AddScoped<IBaseRepository<Sleep>, SleepRepository>();
            services.AddScoped<IBaseRepository<Exercise>, ExerciseRepository>();
            services.AddScoped<IBaseRepository<Product>, ProductRepository>();
            services.AddScoped<IBaseRepository<ExerciseToList>, ExerciseToListRepository>();
            services.AddScoped<IBaseRepository<ProductToList>, ProductToListRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IProductListService, ProductListService>();
            services.AddScoped<IExerciseListService, ExerciseListService>();
            services.AddScoped<ISleepService, SleepService>();
			services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IExerciseToListService, ExerciseToListService>();
            services.AddScoped<IProductToListService, ProductToListService>();

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options => {
					options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Home/Error";
                });

            services.AddMvc(options => options.EnableEndpointRouting = false);
			services.AddMemoryCache();
			services.AddSession();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseSession();
			app.UseMvc(routes =>
			{
				routes.MapRoute(name: "default",
				template: "{controller=Account}/{action=Login}/{id?}");
			});
		}
	}
}