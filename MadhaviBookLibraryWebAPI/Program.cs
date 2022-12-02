using Microsoft.EntityFrameworkCore;
using MadhaviBookLibraryWebAPI.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IssueDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("ConnSqlServer"))
    );

var policyCORS1 = "_policyCORS1";

//builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("policyCORS1",
        policy =>
        {
            policy.WithOrigins("http://localhost:50149",
                                "http://www.contoso.com")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });

    options.AddPolicy("AnotherPolicy",
        policy =>
        {
            policy.WithOrigins("http://www.contoso.com")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//                      policy =>
//                      {
//                          policy.WithOrigins("http://localhost:50149").AllowAnyMethod()
//                          .AllowAnyHeader()
//                          .AllowAnyHeader()
//                          .AllowCredentials();
//                      });
//    options.AddDefaultPolicy(
//                  policy =>
//                      {
//                          policy.WithOrigins("http://localhost:50149").AllowAnyMethod()
//                          .AllowAnyHeader()
//                          .AllowAnyHeader()
//                          .AllowCredentials();
//                      });

//});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    
    app.UseSwagger();
    app.UseSwaggerUI();
   // app.UseCors("MyAllowSpecificOrigins");
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("policyCORS1");
app.Run();
