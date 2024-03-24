using Azure.Storage.Blobs;
using ServicesProvider.UI;
using ServicesProvider.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/",async c =>
{
    c.Response.Redirect("swagger");
});
app.Logger.LogInformation("===========> Application started successfully  <============");
app.Logger.LogInformation("===========> Application started successfully  <============");
app.Logger.LogInformation("===========> Application started successfully  <============");

app.Run();
