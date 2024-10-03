using System.Text;
using Application.Service;
using Domain.InterfacesServices.Security;
using Domain.InterfacesStores.Security;
using Infrastructure.Exceptions;
using Infrastructure.Entities;
using Insfrastructure.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Insfrastructure.Stores;
using Insfrastructure.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Domain.Models.Security;
using Infrastructure.Stores.Localisation;
using Infrastructure.Stores.Security;
using Domain.InterfacesStores.Localisation;
using Application.Service.Localisation;
using Insfrastructure.Initialiser;
using Domain.InterfacesServices.Parameters;
using Application.Services.Parameters;
using Domain.InterfacesStores.Parameters;
using Insfrastructure.Stores.Parameters;
using Domain.InterfacesServices.File;
using Application.Services.File;
using Domain.InterfacesStores.File;
using Insfrastructure.Stores.FIles;

using IdentityModel;

using Domain.InterfacesServices.Sms;

const string DefaultConnectionString = "DefaultConnection";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var configuration = builder.Configuration;


var jwtSettings = configuration.GetSection("JwtSettings");
var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);


builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(jwt =>
{
    jwt.RequireHttpsMetadata = false;
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAutoMapper(typeof(AutoMapping));
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(swaggerGenOptions =>
{


    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "e-GCERegAPI", Version = "v1" });

    swaggerGenOptions.AddServer(new OpenApiServer { Url = "http://localhost:5136" });

    // swaggerGenOptions.AddServer(new OpenApiServer { Url = "https://e-gceregAPI.runasp.net" });

    // Define the BearerAuth scheme

    swaggerGenOptions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    swaggerGenOptions.OperationFilter<OperationIdFilter>();

    swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
         {
           new OpenApiSecurityScheme
           {
              Reference = new OpenApiReference
              {
                 Type = ReferenceType.SecurityScheme,
                 Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
});



builder.Services.AddCors();


builder.Services.AddDbContext<FsContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString(DefaultConnectionString)));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IUserStore, UserStore>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJobStore, JobStore>();
builder.Services.AddScoped<IJobService, JobService>();


builder.Services.AddScoped<IExamCentreStore, ExamCentreStore>();
builder.Services.AddScoped<IExamCentreService, ExamCentreService>();

builder.Services.AddScoped<IDivisionStore, DivisionStore>();
builder.Services.AddScoped<IDivisionService, DivisionService>();

builder.Services.AddScoped<ICountryStore, CountryStore>();
builder.Services.AddScoped<ICountryService, CountryService>();

builder.Services.AddScoped<ISubDivisionStore, SubDivisionStore>();
builder.Services.AddScoped<ISubDivisionService, SubDivisionService>();

builder.Services.AddScoped<IRegionStore, RegionStore>();
builder.Services.AddScoped<IRegionService, RegionService>();

builder.Services.AddScoped<IMouchardStore, MouchardStore>();
builder.Services.AddScoped<IMouchardService, MouchardService>();

//builder.Services.AddScoped<IBusinessDayStore, BusinessDayStore>();
//builder.Services.AddScoped<IBusinessDayService, BusinessDayService>();

builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IProfileStore, ProfileStore>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

//builder.Services.AddScoped<ICompanyService, CompanyService>();
//builder.Services.AddScoped<ICompanyStore, CompanyStore>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFileStore, FileStore>();

//builder.Services.AddScoped<IBudgetService, BudgetService>();
//builder.Services.AddScoped<IBudgetStore, BudgetStore>();

//builder.Services.AddScoped<IDigitalPaymentMethodStore, DigitalPaymentMethodStore>();
//builder.Services.AddScoped<IDigitalPaymentMethodService, DigitalPaymentMethodService>();

//builder.Services.AddScoped<IBankStore, BankStore>();
//builder.Services.AddScoped<IBankService, BankService>();

//builder.Services.AddScoped<ITillStore, TillStore>();
//builder.Services.AddScoped<ITillService, TillService>();

//builder.Services.AddScoped<IUserTillStore, UserTillStore>();
//builder.Services.AddScoped<IUserTillService, UserTillService>();

builder.Services.AddHttpClient();
builder.Services.AddScoped<ISmsService, SmsService>();

var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None); // Prevent controller expansion by default
});


app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true) // allow any origin
              .AllowCredentials()); // allow credentials

app.Use(async (context, next) =>
{
    // You can access the HttpContext here
    await next();
});

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<FsContext>();
        var password_hash = services.GetRequiredService<IPasswordHasher<User>>();
        InventoryInitializer.Seed(context, password_hash);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

app.UseMiddleware<MouchardMiddleware>();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class OperationIdFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Customize the operation ID as needed. For example, you can use a combination of controller and action names:
        operation.OperationId = $"{context.MethodInfo.DeclaringType.Name}_{context.MethodInfo.Name}";
    }
}