using UserAPI.Infra.IoC.Extensions;
using UsersAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSqaggerDoc();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddJwtBearer();

builder.Services.AddCorsPolicy();

builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapperConfig();
var app = builder.Build();

app.UseSwaggerDoc();
app.UseHttpsRedirection();
//resonsavel pela autenticação e tem que estar nessa ordem
app.UseAuthentication();
app.UseAuthorization();

app.UseCorsPolicy();

app.MapControllers();
app.Run();
