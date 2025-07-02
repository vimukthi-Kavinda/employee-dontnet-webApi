//main settings

using EmployeeWebApi.Data;
using EmployeeWebApi.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);

//------------wire in support-- ef core security
// Add services to the container.

// add db connections and etc..

builder.Services.AddControllers();

//program.cs is like main class in spboot
builder.Services.AddDbContext<DataContext>(options => { // injecting db connectoin details to dbcontext
    options.UseSqlServer( //settig sql server
        builder.Configuration.GetConnectionString("DefaultConnection") //this is fetching config from property file..like env.getproperty in java
        );
});

//use DI for seeding// do DI in program.cs


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//------------------------------

var app = builder.Build();




//*---------------------------
//middleware -- http request go through below paths

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



//create migration
//PM > Add - Migration InitialCreation
//To undo this action, use Remove-Migration.
// run migration - Update-Database