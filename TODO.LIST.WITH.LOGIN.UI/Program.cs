using Application;
using Application.Todo.Commands.DeleteTodo;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add Layer Dependency.
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureServices(builder.Configuration);


//builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);


builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

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
app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


