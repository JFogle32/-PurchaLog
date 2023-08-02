using MyCLOSET.Models;    // Assuming this is the namespace where your User model and repository reside
using MyCLOSET.Repositories; // Assumin

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add your User repository to the DI container.
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ClothesRepository>();
builder.Services.AddTransient<GadgetsRepository>();
builder.Services.AddTransient<ShoesRepository>(););



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();   
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
