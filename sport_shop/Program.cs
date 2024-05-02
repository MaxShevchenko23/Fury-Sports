using Microsoft.EntityFrameworkCore;
using sport_shop_bll.Services;
using sport_shop_dal.Data;
using sport_shop_dal.Interfaces;
using Serilog;
using Serilog.Formatting.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(new JsonFormatter())
    .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
	Log.Information("app started");

	var builder = WebApplication.CreateBuilder(args);

	builder.Host.UseSerilog();

	builder.Services.AddControllers().AddJsonOptions(x =>
				   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

	//builder.Services.AddControllers()

	//builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
	//options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console());

    builder.Services.AddDbContext<FurySportsContext>(contextOptions => contextOptions.UseSqlServer("Data Source=sportshop.database.windows.net;Initial Catalog=sportshopdb;User ID=furyAdmin;Password=Administrastor1;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

	builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


	builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
	builder.Services.AddScoped<ProductService>();
	builder.Services.AddScoped<SpecificationService>();
	builder.Services.AddScoped<CategoryService>();
	builder.Services.AddScoped<ManufacturerService>();
	builder.Services.AddScoped<ReviewService>();
	builder.Services.AddScoped<OrderService>();
	builder.Services.AddScoped<AccountService>();

	builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "AllowLocalHost", policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500");
        });
    });

    var app = builder.Build();

	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseCors("AllowLocalHost");

	app.UseHttpsRedirection();

	app.UseAuthorization();

	app.MapControllers();

	app.Run();

}
catch (Exception e)
{
	Log.Fatal(e, "Host terminated unexpectedly");
}
finally
{
	Log.CloseAndFlush();
}