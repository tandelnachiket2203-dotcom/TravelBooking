using Microsoft.EntityFrameworkCore;
using TravelBooking.Data;
using TravelBooking.Mapping;
using TravelBooking.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TravellBokkingDBContext>(options =>
    options.UseSqlite("Data Source=app.db"));

// builder.Services.AddDbContext<TravellBokkingDBContext>(options => 
// options.UseSqlServer(builder.Configuration.GetConnectionString("TravelBookingConnectionString")));

builder.Services.AddScoped<IDestinationRepository, SQLDestinationRepository>();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
