using Vektorel_234_CRMWebUI.Middleware;
using Vektorel_234_CRMWebUI.SessionHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
}); 
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAntiforgery(opt => opt.HeaderName = "XSRF-Token");
var app = builder.Build();
AppHttpContext.ServiceProvider = app.Services;

app.UseSession();

app.UseGlobalExceptionHandler();
app.UseSessionNullCheckMiddleware();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
