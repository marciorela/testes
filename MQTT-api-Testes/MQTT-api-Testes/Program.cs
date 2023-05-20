using MQTTnet.Server;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var optionsBuilder = new MqttServerOptionsBuilder()
.WithApplicationMessageInterceptor(context =>
{
    if (context.ApplicationMessage.Topic == "teste/topic1")
{
        String inPayload = context.ApplicationMessage.Payload.ToString();
        Console.WriteLine("Mensagem Recebida!! {0}",inPayload);
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run("http://*:5000");

