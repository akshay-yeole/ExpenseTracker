using ExpenseTracker.Contracts;
using ExpenseTracker.Core.AppExceptions;
using ExpenseTracker.ExpenseDataContext;
using ExpenseTracker.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();

builder.Services.AddExceptionHandler<AppExceptionHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ExpenseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

//app.UseDefaultFiles();
//app.UseStaticFiles();

app.UseExceptionHandler(_ => { });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");
app.UseAuthorization();
app.MapControllers();
//app.MapFallbackToFile("index.html");
app.Run();
