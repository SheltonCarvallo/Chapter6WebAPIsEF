using EFCoreData.Data;
using InvoicePeople.Interfaces;
using InvoicePeople.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


namespace InvoiceSuperHeroes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyHeader();
                    });
            });

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            builder.Services.AddScoped<IInvoice, InvoiceService>();
            builder.Services.AddDbContext<InvoiceDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            ));
            
           // builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
