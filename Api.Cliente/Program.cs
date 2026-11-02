

using Api.Cliente.Repositories;

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

#region Injeção de dependência

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped( map => new ClienteRepository(connectionString!));

#endregion

#region Configuração do CORS

var allowedOrigins = builder.Configuration
                            .GetSection("Cors:AllowedOrigins")
                            .Get<string[]>();

builder.Services.AddCors(options =>
 {

     options.AddPolicy("CorsPolicy", policy =>
     {
         policy.WithOrigins(allowedOrigins!)
               .AllowAnyHeader()
               .AllowAnyMethod();
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

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
