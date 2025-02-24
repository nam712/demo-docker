using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();

    if (!context.Products.Any())
    {
        context.Products.AddRange(
               new Product
               {
                   Barcode = "1234567890",
                   Name = "Laptop Dell XPS 15",
                   CategoryName = "Electronics",
                   PurchasePrice = 1500.00m,
                   SalePrice = 1800.00m,
                   Notes = "Laptop m?nh m? cho l?p trình viên"
               },
                new Product
                {
                    Barcode = "0987654321",
                    Name = "iPhone 15 Pro",
                    CategoryName = "Smartphone",
                    PurchasePrice = 1200.00m,
                    SalePrice = 1400.00m,
                    Notes = "?i?n tho?i cao c?p c?a Apple"
                }
            );
        context.SaveChanges();
    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();
