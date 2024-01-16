using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddDefaultPolicy((policy) => 
                                    policy.AllowAnyMethod()
                                          .AllowAnyHeader()
                                          .AllowCredentials()
                                          .SetIsOriginAllowed(origin => true)
                                    ));
// add signalR
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<BusinessHub>();
var app = builder.Build();
app.UseCors();
app.UseRouting();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// define hubs subscribtion
app.UseEndpoints(endpoints =>

{
    endpoints.MapHub<MyFirstHub>("/myfirsthub");
    endpoints.MapHub<MessageHub>("/messagehub");
    endpoints.MapControllers();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
