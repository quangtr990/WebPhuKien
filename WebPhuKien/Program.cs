using Microsoft.EntityFrameworkCore;
using WebPhuKien.Data;
using WebPhuKien;
using System.Net;
using WebPhuKien.Pages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddEndpointsApiExplorer();
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connString!));
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<HoaDonService>();
builder.Services.AddScoped<ChiTietHoaDonService>();
builder.Services.AddScoped<KhachHangService>();
builder.Services.AddScoped<SanPhamService>();
builder.Services.AddScoped<LoaiSanPhamService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.Run();
