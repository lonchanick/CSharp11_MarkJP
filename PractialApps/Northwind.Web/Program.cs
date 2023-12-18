using Packt.Shared;
//An ASP.NET Core project is like a top-level console app, with a hidden <Main>$ method
//as its entry point that has an argument passed using the name args.

var builder = WebApplication.CreateBuilder(args);
//before the statement that builds the app,
builder.Services.AddRazorPages();//me
builder.Services.AddNorthwindContext();//me

var app = builder.Build();


if (!app.Environment.IsDevelopment())//me
{
    app.UseHsts();
}

app.UseHttpsRedirection();//me

//enable static files and default files. Also, modify the statement that maps a GET request to return 
//the Hello World! plain text response to only respond to the URL path /hello, as shown highlighted
//in the following code
app.UseDefaultFiles();//The call to UseDefaultFiles must come before the call to UseStaticFiles
app.UseStaticFiles();

app.MapRazorPages();//me
app.MapGet("/hello", () => "Hello World!");//edited by me
app.Run();

WriteLine("This is executed after server has stoped");
