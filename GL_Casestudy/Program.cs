using GL_Casestudy.DAL;
using GL_Casestudy.DAL.DomainClasses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add the connectionString variable to connect to the DB and then set up the DB layer
var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddDbContext<AppDbContext>(c =>c.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure CORS to be able to get calls from front end
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy => policy.WithOrigins("http://localhost:9004").AllowAnyMethod().AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();

    if(!context.Brands.Any())
    {
        context.Brands.AddRange(
            new Brand { Name = "Asus" },
            new Brand { Name = "Corsair" },
            new Brand { Name = "MSI" }
        );
        
        context.SaveChanges();
    }

    if(!context.Products.Any())
    {
        context.Products.AddRange(
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 1,
                ProductName = "ROG Strix Z790-E Gaming WiFi",
                GraphicName = "asusrogstrix.jpg",
                CostPrice = 280m,
                MSRP = 400m,
                QtyOnHand = 2,
                QtyOnBackOrder = 0,
                Description = "High-end Z790 motherboard with PCIe 5.0 and DDR5 support, perfect for 13th Gen Intel gaming builds."

            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 1,
                ProductName = "TUF Gaming GeForce RTX 4070 Ti",
                GraphicName = "asustufRTX4070.png",
                CostPrice = 610m,
                MSRP = 800m,
                QtyOnHand = 4,
                QtyOnBackOrder = 0,
                Description = "Robust triple-fan RTX 4070 Ti GPU with military-grade components for optimal 1440p gaming."
            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 1,
                ProductName = "ROG Ryujin III 360 ARGB",
                GraphicName = "ryujinIII.png",
                CostPrice = 200m,
                MSRP = 280m,
                QtyOnHand = 2,
                QtyOnBackOrder = 2,
                Description = "Premium 360mm liquid cooler with customizable display and advanced ARGB lighting features."
            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 1,
                ProductName = "ASUS VG248QG Monitor",
                GraphicName = "asusVG248QGMon.png",
                CostPrice = 280m,
                MSRP = 400m,
                QtyOnHand = 2,
                QtyOnBackOrder = 3,
                Description = "Fast 165Hz 24-inch gaming monitor with 0.5ms response time and NVIDIA G-Sync compatibility."
            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 1,
                ProductName = "ASUS ROG Swift PG42UQ OLED",
                GraphicName = "asusROGSwift.png",
                CostPrice = 950m,
                MSRP = 1400m,
                QtyOnHand = 4,
                QtyOnBackOrder = 0,
                Description = "Immersive 42” 4K OLED gaming monitor offering rich colors, 138Hz refresh rate, and DisplayHDR 600."
            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 2,
                ProductName = "Corsair Vengeance RGB Pro 32GB DDR4",
                GraphicName = "corsairvengeance.png",
                CostPrice = 90m,
                MSRP = 130m,
                QtyOnHand = 10,
                QtyOnBackOrder = 0,
                Description = "High-performance DDR4 memory with vibrant RGB lighting for gamers and PC enthusiasts."
            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 2,
                ProductName = "Corsair RM850x 850W PSU",
                GraphicName = "corsairrm850x.png",
                CostPrice = 95m,
                MSRP = 140m,
                QtyOnHand = 6,
                QtyOnBackOrder = 1,
                Description = "Fully modular 850W power supply with 80 Plus Gold certification and zero RPM fan mode."
            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 2,
                ProductName = "Corsair iCUE H150i Elite Capellix",
                GraphicName = "corsairh150i.png",
                CostPrice = 130m,
                MSRP = 180m,
                QtyOnHand = 3,
                QtyOnBackOrder = 2,
                Description = "360mm liquid CPU cooler with dynamic RGB pump head and powerful cooling performance."
            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 2,
                ProductName = "Corsair K95 RGB Platinum XT",
                GraphicName = "corsairk95.png",
                CostPrice = 120m,
                MSRP = 180m,
                QtyOnHand = 5,
                QtyOnBackOrder = 0,
                Description = "Mechanical gaming keyboard with macro keys, per-key RGB lighting, and Elgato Stream Deck integration."
            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 2,
                ProductName = "Corsair 4000D Airflow Case",
                GraphicName = "corsair4000d.png",
                CostPrice = 60m,
                MSRP = 95m,
                QtyOnHand = 8,
                QtyOnBackOrder = 0,
                Description = "Mid-tower case with optimized airflow design and front mesh panel for excellent cooling potential."
            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 3,
                ProductName = "MSI MAG B760 TOMAHAWK WiFi DDR4",
                GraphicName = "msitomahawk.png",
                CostPrice = 140m,
                MSRP = 190m,
                QtyOnHand = 4,
                QtyOnBackOrder = 2,
                Description = "ATX motherboard featuring PCIe 4.0 support, WiFi 6E, and reinforced VRMs for stable Intel performance."
            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 3,
                ProductName = "MSI GeForce RTX 4070 GAMING X TRIO",
                GraphicName = "msigamingx4070.png",
                CostPrice = 580m,
                MSRP = 760m,
                QtyOnHand = 3,
                QtyOnBackOrder = 1,
                Description = "Triple-fan RTX 4070 graphics card with enhanced cooling and silent mode for peak 1440p gaming."
            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 3,
                ProductName = "MSI Optix MAG274QRF-QD",
                GraphicName = "msioptix274.png",
                CostPrice = 300m,
                MSRP = 450m,
                QtyOnHand = 2,
                QtyOnBackOrder = 0,
                Description = "27-inch gaming monitor with QHD resolution, 165Hz refresh rate, and quantum dot tech for vibrant color."
            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 3,
                ProductName = "MSI SPATIUM M480 PRO 2TB SSD",
                GraphicName = "msissdm480pro.png",
                CostPrice = 170m,
                MSRP = 250m,
                QtyOnHand = 7,
                QtyOnBackOrder = 0,
                Description = "High-speed NVMe Gen4 SSD with heatsink, ideal for demanding gaming and workstation applications."
            },
            new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                BrandId = 3,
                ProductName = "MSI MPG GUNGNIR 110R Case",
                GraphicName = "msigungnir110r.png",
                CostPrice = 75m,
                MSRP = 110m,
                QtyOnHand = 5,
                QtyOnBackOrder = 2,
                Description = "Stylish mid-tower case with tempered glass panel, RGB lighting, and strong airflow support for gamers."
            }
        );

        context.SaveChanges();
    }
}

app.Run();
