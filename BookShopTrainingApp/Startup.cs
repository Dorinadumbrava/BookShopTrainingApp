using AutoMapper;
using BookShopTrainingApp.Application.AddBook;
using BookShopTrainingApp.Application.AddPurchase;
using BookShopTrainingApp.Application.Mailing;
using BookShopTrainingApp.Application.PurchasesReport;
using BookShopTrainingApp.Core;
using BookShopTrainingApp.Persistence;
using BookShopTrainingApp.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace BookShopTrainingApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => c.CustomSchemaIds(x => x.FullName));
            services.AddAutoMapper(typeof(BooksAutomapperProfile), typeof(PurchaseAutomapperProfile));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookShopContext, BookShopContext>();
            services.AddScoped<ISupplyBookService, SupplyBookService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IMailingService, MailingService>();
            services.AddScoped<IMailWrapper, MailWrapper>();
            services.AddScoped<IReportingService, ReportingService>();
            services.AddScoped<IExcelCreator, ExcelCreator>();
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(IMailingService).Assembly);
            services.AddDbContext<BookShopContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString(Constants.connectionString)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BookShopContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            context.Database.EnsureCreated();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}