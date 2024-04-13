using BeautySalon.InfraStructure.Contexts;
using BeautySalon.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:800")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
var a = builder.Configuration.GetConnectionString("BeautySalon");
builder.Services.AddDbContext<BeautySalonContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("BeautySalon")));
builder.Services
    .AddIdentityCore<ApplicationUser>()
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<BeautySalonContext>()
    .AddDefaultTokenProviders();

//builder.Services.AddDbContext<BeautySalonContext>();
//builder.Services.AddScoped<BeautySalonContext>(sp => sp.GetRequiredService<BeautySalonContext>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseStaticFiles();
//app.UseMiddleware(typeof(CustomExceptionHandlerMiddleware));

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();


//builder.Services.AddSwaggerGen(options =>
//{
//    options.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "Ordering HTTP API",
//        Version = "v1",
//        Description = "The Ordering Service HTTP API",
//    });
//    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Description = "JWT Authorization header using the bearer scheme",
//        Name = "Authorization",
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.ApiKey
//    });
//    options.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Id = "Bearer",
//                    Type = ReferenceType.SecurityScheme
//                }
//            },
//            new List<string>()
//        }
//    });
//});


////builder.Services.Configure<ImagePathProvider>(x => x.ImagePath = builder.Configuration.GetValue<string>("ImagePath"));
////ImagePathProvider.HttpImagePath = builder.Configuration.GetValue<string>("HttpImagePath");

//builder.Services
//    .AddIdentityCore<ApplicationUser>()
//    .AddRoles<ApplicationRole>()
//    .AddEntityFrameworkStores<BeautySalonContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(cfg =>
//    {
//        cfg.TokenValidationParameters = new TokenValidationParameters()
//        {
//            ValidateIssuer = false,
//            ValidateAudience = false,
//            ValidateIssuerSigningKey = true,
//            RequireExpirationTime = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("vjhgjhgbk32ییسشjkjloij6576hiuhiujhgh87y"))
//        };
//    });

//builder.Services.AddAuthorization(
////    options =>
////{
////    options.AddPolicy("UserPolicy",
////    policyBuilder => policyBuilder.RequireRole("User"));
////}
//);

////builder.Services.AddAutoMapper(typeof(MappingProfile));

////var httpImagePath = builder.Configuration.GetValue<string>("HttpImagePath");
//var beautySalonOrgin = builder.Configuration.GetValue<string>("BeautySalonOrgin");

////builder.Services.AddCors(option =>
////{
////    option.AddPolicy("CorsPolicy", builder =>
////    {
////        //builder.WithOrigins(httpImagePath, beautySalonOrgin)
////        builder //.WithOrigins(beautySalonOrgin)
////        .AllowAnyMethod()
////        .AllowAnyHeader()
////        .AllowCredentials();
////    });
////});

