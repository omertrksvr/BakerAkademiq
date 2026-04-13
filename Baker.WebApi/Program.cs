using Baker.WebApi.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BakerContext>();
builder.Services.AddControllers(); // ✅ API için bu
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer(); // opsiyonel
builder.Services.AddSwaggerGen(); // opsiyonel

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();       // opsiyonel
    app.UseSwaggerUI();     // opsiyonel
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers(); // ✅ API için bu

app.Run();