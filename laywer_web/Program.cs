using laywer_web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

/* to create the database*/
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext<mycontext>(
    Options => Options.UseSqlServer(
        builder.Configuration.GetConnectionString("conn"))

   );
/* to use the session in our website */
builder.Services.AddSession() ;

var app = builder.Build();

/*to set the default route*/
app.MapControllerRoute(
    name:"defualt",
    pattern:"{controller=home}/{action=index}"
    );
/*to use static files of the project in our web*/
app.UseStaticFiles();

/* to use the session in our website*/
app.UseSession();

app.Run();
