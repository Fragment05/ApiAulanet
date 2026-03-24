var builder = WebApplication.CreateBuilder(args);

//área de servicios
builder.Services.AddControllers();

//Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Area de middlewares
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
