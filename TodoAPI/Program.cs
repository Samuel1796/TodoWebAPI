var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Configuration - More Permissive
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins(
                "http://localhost:4200",   // Angular app
                "https://localhost:4200"   // Added https variant
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());  // Added this line
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// IMPORTANT: Middleware order matters
app.UseCors("AllowAngularApp");  // Move this before UseHttpsRedirection
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();