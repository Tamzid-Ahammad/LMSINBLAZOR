using BlazorApp1.Client.Pages;
using BlazorApp1.Client.Services;
using BlazorApp1.Components;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BlazorApp1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<LibraryDB>(opt =>
		opt.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LMSBLAZOREXAMS;Trusted_Connection=True")
		);

			builder.Services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
			});

			builder.Services.AddHttpClient<BookService>();
			// Add services to the container.
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents()
				.AddInteractiveWebAssemblyComponents();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();
			app.UseAntiforgery();
			app.MapControllers();
			app.MapRazorComponents<App>()
				.AddInteractiveServerRenderMode()
				.AddInteractiveWebAssemblyRenderMode()
				.AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

			app.Run();
		}
	}
}
