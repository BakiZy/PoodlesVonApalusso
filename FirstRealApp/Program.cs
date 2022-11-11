using FirstRealApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System.Text;
using FirstRealApp.Repository;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.OpenApi.Models;
using FirstRealApp.Services;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;


// Add services to the container.

//for entity framework
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("LocalConnectionString")));

}

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AppConnectionString")));



//for identity 
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//adding authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})



//adding JWT bearer
.AddJwtBearer(options =>
{

    options.SaveToken = true;
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidAudience = configuration["Jwt:Audience"],
        ValidIssuer = configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),


    };
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequiredAdminRole", policy => policy.RequireRole("Admin"));
});


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins(
                    "http://localhost:3000",
                    "https://localhost:3000",
                    "https://localhost:5000",
                    "http://localhost:5000",
                    "https://localhost:44373",
                    "http://localhost:44373",
                    "https://poodlesvonapalusso.xyz",
                    "https://poodlesvonapalusso.dog",
                    "https://api.poodlesvonapalusso.dog",
                    "http://www.poodlesvonapalusso.dog",
                    "http://www.poodlesvonapalusso.xyz",
                    "https://www.poodlesvonapalusso.dog",
                    "https://www.poodlesvonapalusso.xyz",
                    "http://www.web.skenit.com",
                    "https://vonapalusso.netlify.app",
                    "http://www.vonapalusso.netlify.app",
                    "https://armando.ns.cloudflare.comm",
                    "https://katja.ns.cloudflare.com",
                    "https://win5232.site4now.net",
                    "https://api.imgur.com/",
                    "https://imgur.com",
                    "https://i.imgur.com",
                     "http://imgur.com",
                    "http://i.imgur.com",
                    "http://bakisan-001-site1.ctempurl.com",
                    "https://bakisan-001-site1.ctempurl.com/",
                    "https://dns1.p02.nsone.net",
                    "https://dns2.p02.nsone.net",
                    "https://dns3.p02.nsone.net",
                    "https://dns4.p02.nsone.net",
                    "https://win5232.site4now.net:8172/MsDeploy.axd?site=bakisan-001-site1")
                .AllowAnyHeader()
                .AllowCredentials()
                .AllowAnyMethod();
        });

    /*  options.AddDefaultPolicy(

          builder =>
          {
              builder.WithOrigins("*").AllowAnyHeader().AllowAnyHeader();
          });*/
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Poodle CRUD api with authorization and authentication",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddScoped<IPoodlesRepository, PoodlesRepository>();
builder.Services.AddScoped<IPoodleColorsRepository, PoodleColorsRepository>();
builder.Services.AddScoped<IFilterService, FilterService>();
builder.Services.AddScoped<IImagesRepository, ImagesRepository>();
builder.Services.AddAutoMapper(typeof(PoodleProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.UseEndpoints(endpoints =>
   {
       endpoints.MapControllers();
   });

app.Run();

