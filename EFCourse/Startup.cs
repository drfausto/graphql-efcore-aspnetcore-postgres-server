using EFCourse.Data;
using EFCourse.GraphQL;
using EFCourse.Store;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCourse {
  public class Startup {
    public IConfigurationRoot Configuration { get; set; }
    public Startup(IHostingEnvironment env) {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

      if (env.IsDevelopment()) { 
        //app.UseDeveloperExceptionPage(); 
      }

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
    } 
    public void ConfigureServices(IServiceCollection services) {
      services.AddScoped<IDependencyResolver>(
        s => new FuncDependencyResolver(s.GetRequiredService)
      );
      
      services.AddSingleton<IDocumentWriter, DocumentWriter>();
      services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
      services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
      services.AddSingleton<DataLoaderDocumentListener>();
        // GraphQL clasess for schema and resolvers for queries and mutations
      services.AddScoped<ISchema, CourseSchema>();
      services.AddScoped<CourseQuery>();
      services.AddScoped<CourseMutation>();      
        // *InputType: type of mutation arguments
        // *Type: type of objects that GraphQL mutations and queries return 
      services.AddScoped<UniversityType>();
      services.AddScoped<UniversityInputType>();
      services.AddScoped<DepartmentType>();
      services.AddScoped<DepartmentInputType>();
      services.AddScoped<CourseType>();
      services.AddScoped<CourseInputType>();
        // Class DataStore implements IDataStore interface
        // that defines CRUD methods to manage the DataStore
      services.AddScoped<IDataStore, DataStore>();
        // Class CourseContext is used by EFCore to build DB, to
        // map objects in code to entities in DB and to manage DB
      services.AddDbContext<CourseContext>();
    }
      // This method gets called by the runtime. 
      // Use this method to configure HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseMiddleware<GraphQLMiddleware>();
    }
  }
}
