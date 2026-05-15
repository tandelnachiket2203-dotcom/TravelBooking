using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TravelBooking.Data;
using TravelBooking.Mapping;
using TravelBooking.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TravellBokkingDBContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("TravelBookingConnectionString")));
builder.Services.AddDbContext<TravellBookingAuthDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("TravelBookingAuthConnectionString")));

builder.Services.AddScoped<IDestinationRepository, SQLDestinationRepository>();
builder.Services.AddScoped<ITokenRepositry, TokenRepository>();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());
builder.Services.AddIdentityCore<IdentityUser>().
    AddRoles<IdentityRole>().
    AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("TravelBookingApi")
    .AddEntityFrameworkStores<TravellBookingAuthDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(option => { 
option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
        option.Password.RequireUppercase = false;
            option.Password.RequireNonAlphanumeric = false;
     option.Password.RequiredLength = 8;
    option.Password.RequiredUniqueChars = 1;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer((option => option.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer=true,
    ValidateAudience=true,
    ValidateLifetime=true,
    ValidateIssuerSigningKey=true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
