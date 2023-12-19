using Packt.Shared;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();//dependecy injection

builder.Services.AddNorthwindContext();//dependency injection

var app = builder.Build();

if(!builder.Environment.IsDevelopment())
    app.UseHsts();    

app.UseHttpsRedirection();

//MIDDLEWARES:
// the ordering of middleware IS CRUCIAL
app.UseDefaultFiles();//first one
app.UseStaticFiles();//secondone

app.MapRazorPages();

app.MapGet("/hello", () => "Hello World!");

app.Run();
