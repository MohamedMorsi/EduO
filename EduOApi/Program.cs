using EduO.Api.Helpers.Factory;
using EduO.Api.Services;
using EduO.Api.Services.Contracts;
using EduO.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//ApplicationDbContext 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(connectionString,
             b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));    

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Cors
builder.Services.AddCors();

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Register Identity
builder.Services.AddIdentity<User, Role>(opt =>
{
    opt.Password.RequiredLength = 3;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = false;

    opt.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomClaimsFactory>();

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//JwtSettings
var jwtSettings = builder.Configuration.GetSection("JWTSettings");
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["validIssuer"],
        ValidAudience = jwtSettings["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["securityKey"]))
    };
});

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAuthService, AuthService>();

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Services
builder.Services.AddTransient<IBaseService<ExClass>, ExClassService>();
builder.Services.AddTransient<IBaseService<Grade>, GradeService>();
builder.Services.AddTransient<IBaseService<Teacher>, TeacherService>();
builder.Services.AddTransient<IBaseService<Student>, StudentService>();
//builder.Services.AddTransient<IGradeService, GradeService>();



/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo 
    {
        Version = "v1",
        Title = "EduO.Api",
        Description = "api",
        TermsOfService = new Uri("https://www.google.com"),
        Contact = new OpenApiContact 
        {
            Name = "EduO",
            Email = "test@domain.com",
            Url = new Uri("https://www.google.com")
        },
        License = new OpenApiLicense
        {
            Name = "My license",
            Url = new Uri("https://www.google.com")
        }
    });

    //Auth For OpenApi
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\""
    });

    //add Auth for each point
    options.AddSecurityRequirement(new OpenApiSecurityRequirement 
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var app = builder.Build();

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//upload files
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
    RequestPath = new PathString("/StaticFiles")
});

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Seednig data in first run 
using var scope = app.Services.CreateScope();   
var services = scope.ServiceProvider;

//Create Logger
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("app");

try
{
    var userManger = services.GetRequiredService<UserManager<User>>();
    var roleManger = services.GetRequiredService<RoleManager<Role>>();

    await EduO.ORM.Seeds.RoleSeeds.SeedRoles(roleManger);
    await EduO.ORM.Seeds.UserSeeds.SeedUsers(userManger,roleManger);

    logger.LogInformation("Roles & First User seeded");
    logger.LogInformation("Application Started");
}
catch (Exception ex)
{
    logger.LogWarning("Seeding Data Failed");
    logger.LogWarning("ex : " + ex);
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//allow cors 
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
