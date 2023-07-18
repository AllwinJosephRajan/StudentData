using InterviewAssignmentTry3.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Configure Database

var connectString = builder.Configuration.GetConnectionString("StudentDbConnection");
builder.Services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(connectString));

#endregion

var cultureInfo = new CultureInfo("en-US");
cultureInfo.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "students",
        pattern: "{controller=Student}/{action=Index}/{searchName?}/{searchFromDate?}/{searchToDate?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Student}/{action=Index}/{id?}");
});
app.Run();
