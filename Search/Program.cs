using Search.Interface;
using Search.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IClientService, ClientService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<ISaleService, SaleService>();

builder.Services.AddHttpClient("clientService", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Services:Client"]);
});
builder.Services.AddHttpClient("productService", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Services:Product"]);
});
builder.Services.AddHttpClient("saleService", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Services:Sale"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
