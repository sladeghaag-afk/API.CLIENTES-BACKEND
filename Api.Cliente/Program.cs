

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddOpenApi();

#region Configurando a documentação do Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "API de clientes",
        Version = "v1",
        Description = "API ASP.NET Core com Dapper e SqlServer para CRUD de clientes"
    }); 
    
 });

#endregion

var app = builder.Build();


#region Executar Documentação do Swagger

app.UseSwagger();
app.UseSwaggerUI();

#endregion




if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
  
}

app.UseAuthorization();

app.MapControllers();

app.Run();
