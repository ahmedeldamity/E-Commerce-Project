using API.ServicesExtension;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Data;

#region Update Database Problems And Solution
// To Update Database You Should Do Two Things 
// 1. Create Object From DbContext
//--- StoreDbContext storeDbContext = new StoreDbContext();
// 2. Migrate It
//--- await storeDbContext.Database.MigrateAsync();
// But To Create Instanse From DbContext You Should Have Non Parameterized Constructor In StoreDbContext Class
// But We Not Work With Non Parameterized constractor because if we do it we should override on configuring
// And Then We Not Working With Dependency Injection So That Solution Not Working!!
// And We Try Another Solution Like Ask Clr To Create This Instance Also This Solution Not Working!!
// Because To Ask Clr You Need Constractor And If We Use Normal Program Constractor Not Working
// Because Normal Constractor Work If You Need Object From Class 
// And Function Main Is Static, So We Need To Ask Clr In Static Consractor
// And If We Used Program Static Constractor (Static Constractor Work Just One Time: Before The First Using Of Class)
// So Static Constractor Work Before Main
// And We Configure DbContext Services In Main Function 
// So The Only Solution Is: (I Written It Below)
#endregion

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container

// Register Api Controller
builder.Services.AddControllers();

// Register Required Services For Swagger In Extension Method
builder.Services.AddSwaggerServices();

// Register Store Context
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// This Method Has All Application Services
builder.Services.AddApplicationServices();

#endregion

var app = builder.Build();

#region Update Database With Using Way And Seeding Data

// We Said To Update Database You Should Do Two Things (1. Create Instance From DbContext 2. Migrate It)

// To Ask Clr To Create Instance Explicitly From Any Class
//    1 ->  Create Scope (Life Time Per Request)
using var scope = app.Services.CreateScope();
//    2 ->  Bring Service Provider Of This Scope
var services = scope.ServiceProvider;

// --> Bring Object Of StoreContext For Update Database
var _storeContext = services.GetRequiredService<StoreContext>();
// --> Bring Object Of ILoggerFactory For Good Show Error In Console    
var loggerFactory = services.GetRequiredService<ILoggerFactory>();

try
{
    // Migrate It In Try Catch To Avoid Throw Exception While Update Database
    await _storeContext.Database.MigrateAsync();

    // Seeding Data For StoreDbContext
    await StoreContextSeed.SeedProductDataAsync(_storeContext);
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "an error has been occured during apply the migration!");
}

#endregion

#region Configure the Kestrel pipeline

if (app.Environment.IsDevelopment())
{
    // -- Add Swagger Middelwares In Extension Method
    app.UseSwaggerMiddleware();
}

/// -- In MVC We Used This Way For Routing
///app.UseRouting(); // -> we use this middleware to match request to an endpoint
///app.UseEndpoints  // -> we use this middleware to excute the matched endpoint
///(endpoints =>  
///{
///    endpoints.MapControllerRoute(
///        name: "default",
///        pattern: "{controller}/{action}"
///        );
///});
/// -- But We Use MapController Instead Of It Because We Create Routing On Controller Itself
app.MapControllers(); // -> we use this middleware to talk program that: your routing depend on route written on the controller

#endregion

app.Run();