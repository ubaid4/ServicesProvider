using Azure.Storage.Blobs;
using ServicesProvider.Core.Builders;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Infrastructure.Initializer;
using ServicesProvider.UI;
using ServicesProvider.UI.Extensions;
using ServicesProvider.UI.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();/*.AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);*/
builder.RegisterAppSerilog();
//builder.Services.AddScoped(x=> new BlobServiceClient(builder.Configuration["AzureBlobStorage:ConnectionString"]));
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterAppSwagger(builder.Configuration);

builder.Services.RegisterAppDbContext(builder.Configuration);
builder.Services.RegisterAppIdentity();
builder.Services.RegisterAppAuthentication(builder);
builder.Services.RegisterAppAuthorization();
builder.Services.RegisterAppServices();
builder.Services.RegisterAppRepositories();
builder.Services.RegisterAppConstraints();

builder.Services.AddAutoMapper(typeof(MapperProfile));
var app = builder.Build();
app.UseExceptionHandler("/error");

if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || app.Environment.EnvironmentName=="Stag" )

{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.InjectStylesheet("/swagger-ui/SwaggerDark.css"));
}
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
//add UseJwtTokenAbortedMiddleware if route is other than account becouse account route is open for all users
app.UseWhen(app => !app.Request.Path.StartsWithSegments("/api/Account"), appBuilder =>
{
    appBuilder.UseJwtValidationFailure();
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", async c =>
{
    c.Response.Redirect("swagger");
});

await DbInitializer.InitializeRolesAndUsers(app);

app.Logger.LogWarning("===========> Application started successfully at:" + DateTime.Now.ToString());

app.Run();
