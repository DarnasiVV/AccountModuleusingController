using Marten.Events.Daemon.Resiliency;
using Marten;
using Wolverine;
using Accounting_Module_Example.Projections;
using Marten.Events.Projections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMarten(m =>
{
    m.Connection("Host=localhost;Database=Account;UserName=postgres;Password=test");
    m.Projections.Add<AccountProjection>(ProjectionLifecycle.Async);
}).AddAsyncDaemon(DaemonMode.HotCold).UseLightweightSessions();
builder.Host.UseWolverine();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
