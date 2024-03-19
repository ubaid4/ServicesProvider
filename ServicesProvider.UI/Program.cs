using ServicesProvider.UI;
using ServicesProvider.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.RegisterAppSerilog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterAppSwagger();

builder.Services.RegisterAppDbContext(builder.Configuration);
builder.Services.RegisterAppIdentity();
builder.Services.RegisterAppAuthentication(builder);
builder.Services.RegisterAppAuthorization();
builder.Services.RegisterAppServices();
builder.Services.RegisterAppRepositories();

builder.Services.AddAutoMapper(typeof(MapperProfile));
var app = builder.Build();
app.UseExceptionHandler("/error");

if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || true)
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
app.Run();
