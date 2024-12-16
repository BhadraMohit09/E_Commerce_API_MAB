using NewWebAPI_MAB.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<BillRepository>();

builder.Services.AddScoped<UserRepository>();

builder.Services.AddScoped<ProductRepository>();

builder.Services.AddScoped<CustomerRepository>();

builder.Services.AddScoped<OrderRepository>();

builder.Services.AddScoped<OrderDetailRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
