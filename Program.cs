using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MinihuronBackend.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregamos el servicio del controlador para que estos funcionen de manera correcta
builder.Services.AddControllers();

// Agregamos el servicio de los cors ya que necesitamos configurar de manera correcta los cors para dejar pasar a la persona o ip que tengamos identificada en nuestra lista pero de momento solamente que este ahí para dejar pasar a las personas desde el backend ya si queremos que no todos pase hay que configurarlo
builder.Services.AddCors(options=>{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5226") // Actualiza la URL según sea necesario
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

// Builder para JWT con el token
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(configure =>
{
    configure.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = @Environment.GetEnvironmentVariable("jwtVar"),
        ValidAudience = @Environment.GetEnvironmentVariable("jwtVar"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3C7A6C4E2754B9A31F225E201C02D82E"))
    };
});

// Configuración del servicio de la base de datos
builder.Services.AddDbContext<MiniHuronContext>(Options =>
    Options.UseMySql(builder.Configuration.GetConnectionString("MinihuronDB"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Usamos los cors que previamente configuramos
app.UseCors("AllowAnyOrigin");
// Mapeamos todos los controladores
app.MapControllers();

app.Run();
