using UsersAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSqaggerDoc();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
var app = builder.Build();

app.UseSwaggerDoc();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
