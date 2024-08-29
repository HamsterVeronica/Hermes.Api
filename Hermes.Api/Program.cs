using Hermes.Api.Domain.Contracts.Repositories;
using Hermes.Api.Domain.Contracts.Service;
using Hermes.Api.Infraestructure.Repositories;
using Hermes.Api.Infraestructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGuildMemberRepository, GuildMemberRepository>();
builder.Services.AddScoped<IFormRepository, FormRepository>();

// Services
builder.Services.AddScoped<IGuildMemberService, GuildMemberService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHashService, PasswordHashService>();
builder.Services.AddScoped<IFormService, FormService>();

// CORS Issue
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply CORS policy
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();

