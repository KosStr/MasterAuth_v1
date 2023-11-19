using Autofac;
using Autofac.Extensions.DependencyInjection;
using MasterAuth.Business.Modules;
using MasterAuth.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();

#region ImportExtensions

builder.AddDatabaseContext();
builder.AddSwagger();
builder.AddSingletons();
builder.AddEmail();

#endregion

#region Modules Registration

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new BusinessModule());
    });

#endregion

//builder = new ConfigurationBuilder()
//                .SetBasePath(Environment.ContentRootPath)
//                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//                .AddJsonFile($"appsettings.{Environment.EnvironmentName}.json", optional: true)
//                .AddEnvironmentVariables();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseSwagger(c =>
{
    c.SerializeAsV2 = true;
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MasterAuth");
    c.RoutePrefix = "swagger";
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();