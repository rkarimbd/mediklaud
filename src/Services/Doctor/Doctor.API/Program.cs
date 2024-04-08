var builder = WebApplication.CreateBuilder(args);

// Add Services to the container

builder.Services.AddCarter();
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config=>
{
    config.RegisterServicesFromAssembly(assembly);

});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
   

}).UseLightweightSessions();

var app = builder.Build();

//  Configure HTTP request pipeline

app.MapCarter();



app.Run();
