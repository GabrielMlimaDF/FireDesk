
using NuGet.Protocol.Core.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using FireDesk.Data;
using FireDesk.Services;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FireDesk");
// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<ITicketsRepositorio, TicketsRepositorio>();
builder.Services.AddScoped<TicketServices>();
builder.Services.AddScoped<TecnicosServices>();
builder.Services.AddDbContext<Context>(op=>op.UseSqlServer(connectionString));
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
   
}
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();


}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();