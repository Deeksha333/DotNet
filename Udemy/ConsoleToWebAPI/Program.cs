


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.Run(async context => {
//    await context.Response.WriteAsync("Hello Diksha");

//    });


app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello Diksha from use1- 1\n");
    await next();
    await context.Response.WriteAsync("Hello Diksha from use1- 2\n");
});




app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello Diksha from use2- 1\n");
    await next();
    await context.Response.WriteAsync("Hello Diksha from use2- 2\n");
});

app.Map("/diksha", customcode);

Task customcode(HttpContext context)
{
    return Task.Run(() => "Hello Diksha from custcode");
}

app.Run(async context => {
    await context.Response.WriteAsync("Hello Diksha from run\n");
});





//if (app.Environment.IsDevelopment()) 
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

app.Run();
