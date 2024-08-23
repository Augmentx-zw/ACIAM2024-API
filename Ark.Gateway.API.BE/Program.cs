using Ark.Gateway.API.BE;
using Ark.Gateway.API.BE.Services;
using Ark.Gateway.Domain;
using Ark.Gateway.Domain.CommandHandler;
using Ark.Gateway.Domain.QueryHandlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();

//builder.WebHost.UseUrls("https://localhost:50622");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSingleton<Mediator>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IMessaging, Messaging>();

builder.Services.AddCommandQueryHandlers(typeof(IQueryHandler<,>), "Ark.Gateway.Domain");
builder.Services.AddCommandQueryHandlers(typeof(ICommandHandler<>), "Ark.Gateway.Domain");

builder.Services.AddScoped<IAESEnc, AesImplementation>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseCors(x => x
           .AllowAnyMethod()
           .AllowAnyHeader()
           .SetIsOriginAllowed(origin => true)
           .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
