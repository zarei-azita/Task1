using Data.Initialization;
using Data.Interfaces;
using Data.Services;
using Entities.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddDbContext<MyDBContext>(option => {

    option.UseInMemoryDatabase(builder.Configuration.GetConnectionString("MyDB"));

 });

builder.Services.AddTransient<IStudent, StudentServices>();
builder.Services.AddTransient<IProfessor, ProfessorServices>();
builder.Services.AddTransient<IOther, OtherServices>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("*").
            AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyDBContext>();
    Create create = new Create(dbContext);
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);

app.Run();


