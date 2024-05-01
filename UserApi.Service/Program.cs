using Serilog.Sinks.LogBee.AspNetCore;
using UserApi.Service.Middlewares;
using UserAPI.Infra.IoC.Extensions;
using UsersAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSqaggerDoc();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddJwtBearer(builder.Configuration);

builder.Services.AddCorsPolicy();

builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapperConfig();
builder.Services.AddDbContextConfig(builder.Configuration);
builder.Services.AddRabbitMQ(builder.Configuration);
builder.Services.AddEmailMessage(builder.Configuration);
builder.Services.AddSerilogConfig(builder.Configuration); //Serilog

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwaggerDoc();
app.UseHttpsRedirection();
//resonsavel pela autenticação e tem que estar nessa ordem
app.UseAuthentication();
app.UseAuthorization();

app.UseCorsPolicy();
app.MapControllers();

app.UseLogBeeMiddleware(); //Serilog
app.Run();

public partial class Program { }
