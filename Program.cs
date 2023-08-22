using ConfigExample.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//Injecting App setting configuration specific section as a service to the application
builder.Services.Configure<ClientDataOption>(builder.Configuration.GetSection("ClientData"));
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

//Adding endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/config", async context =>
    {
        //way 1
        await context.Response.WriteAsync(app.Configuration["MyKey"].ToString() + "\n");
        //way 2, using get value
        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey") + "\n");
        //way 3 using getvalue with default value if key not found
        await context.Response.WriteAsync(app.Configuration.GetValue<int>("NewKey", 3).ToString());
    });
});

app.MapControllers();


app.Run();
