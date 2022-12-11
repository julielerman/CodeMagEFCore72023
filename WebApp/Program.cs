
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApp;
using Serilog;
using Serilog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

string _logfile;

if (!EF.IsDesignTime)
{
    _logfile = "logs/myapp.txt";
}
else {
    _logfile = "logs/migrationlog.txt"; 
}

    Log.Logger = new LoggerConfiguration()
   .MinimumLevel.Debug()
   .WriteTo.File(_logfile, rollingInterval: RollingInterval.Day)
   .CreateLogger(); Log.Information($"Initialize Log {DateTime.UtcNow}");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddSerilog();
builder.Services.AddDbContext<LibraryContext>
  (options => options
   .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EFC7CodeMagWeb")
);


//Console.WriteLine($"IsDesignTime:{EF.IsDesignTime}");
var app = builder.Build();
Console.WriteLine("post-app build");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



// TODO: Need a flag to skip during dotnet-ef
//if (!EF.IsDesignTime)
//{
// Migrate
//Console.WriteLine($"IsDesignTime:{EF.IsDesignTime}");
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    db.Database.Migrate();
}


//}

app.MapGet("/books", async (LibraryContext db) => await db.Books.ToListAsync());



app.Run();

