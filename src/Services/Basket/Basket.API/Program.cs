using BuildBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
var connection = builder.Configuration.GetConnectionString("Database");
// Add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBeahavior<,>));
    config.AddOpenBehavior(typeof(LogginBeahavior<,>));

});
builder.Services.AddMarten(opt =>
{
    opt.Connection(connection!);
    //opt.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;
    opt.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
var app = builder.Build();

//Configure the http pipeline
app.MapCarter();
app.UseExceptionHandler(opt => { });
app.Run();
