using Mes_rest_Business.Repository;
using Mes_rest_Business.Repository.IRepository;
using Mes_rest_Common;
using Mes_rest_DataAccess;
using Mes_rest_Models.Mes_restModels;
using Mes_rest_WebAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;


namespace Mes_rest_WebAPI
{

    /// <summary>
    /// Настройка конфигурации приложения
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Конфигурация приложения
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Конфигурация сревисов приложения
        /// </summary>
        /// <param name="services">Интрефейс коллекции сервисов приложения</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddMvcOptions(x =>
                x.SuppressAsyncSuffixInActionNames = false);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                // include API xml documentation
                var apiAssembly = typeof(TagsController).Assembly;
                c.IncludeXmlComments(GetXmlDocumentationFileFor(apiAssembly));

                apiAssembly = typeof(TagValuesController).Assembly;
                c.IncludeXmlComments(GetXmlDocumentationFileFor(apiAssembly));

                // include models xml documentation
                var modelsAssembly = typeof(TagResponse).Assembly;
                c.IncludeXmlComments(GetXmlDocumentationFileFor(modelsAssembly));

                //modelsAssembly = typeof(Catalog_Models.CatalogModels.Publisher.PublisherItemCreateUpdateRequest).Assembly;
                //c.IncludeXmlComments(GetXmlDocumentationFileFor(modelsAssembly));
                //modelsAssembly = typeof(Catalog_Models.CatalogModels.Publisher.PublisherItemResponse).Assembly;
                //c.IncludeXmlComments(GetXmlDocumentationFileFor(modelsAssembly));

                //modelsAssembly = typeof(Catalog_Models.CatalogModels.State.StateItemCreateRequest).Assembly;
                //c.IncludeXmlComments(GetXmlDocumentationFileFor(modelsAssembly));
                //modelsAssembly = typeof(Catalog_Models.CatalogModels.State.StateItemResponse).Assembly;
                //c.IncludeXmlComments(GetXmlDocumentationFileFor(modelsAssembly));
                //modelsAssembly = typeof(Catalog_Models.CatalogModels.State.StateItemUpdateRequest).Assembly;
                //c.IncludeXmlComments(GetXmlDocumentationFileFor(modelsAssembly));

            });


            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagValueRepository, TagValueRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseNpgsql(Configuration.GetConnectionString("Mes_restDBPostgresSQLConnection"),
                            u => u.CommandTimeout(SD.SqlCommandConnectionTimeout));
                    options.UseLazyLoadingProxies();
                });

            services.AddOpenApiDocument(options =>
            {
                options.Title = "Mes_rest API Doc";
                options.Version = "1.0";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Подключение и настройка middleware pipline
        /// </summary>
        /// <param name="app">Интрефейс строителя приложения</param>
        /// <param name="env">Интерфейс конфигурации</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseOpenApi();

            app.UseSwaggerUI(x =>
            {
                x.DocExpansion(DocExpansion.List);
            });
            //    x.SwaggerEndpoint("/openapi/v1.json", "Catalog API ver. 1");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static string GetXmlDocumentationFileFor(Assembly assembly)
        {
            var documentationFile = $"{assembly.GetName().Name}.xml";
            var path = Path.Combine(AppContext.BaseDirectory, documentationFile);

            return path;
        }

    }
}
