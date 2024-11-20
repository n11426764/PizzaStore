using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => { });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
     {
         c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
     });
var app = builder.Build();
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(c =>
     {
         c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
     });
} // end of if (app.Environment.IsDevelopment()) block


app.UseRouting();
app.UseCors(); // Apply CORS policy

// Define endpoints
app.MapGet("/", () => "Hello World!");

// Replace `TodoDb` and `Todo` with actual implementations
// app.MapGet("/todos", async (TodoDb db) => await db.Todos.ToListAsync());
// app.MapPost("/todos", async (Todo todo) =>
// {
//     // Add logic to handle the new todo
// });
// app.MapPut("/todos", (Todo todo) =>
// {
//     // Add logic to update a todo
// });
// app.MapDelete("/todos/{id}", (int id) =>
// {
//     // Add logic to delete a todo by id
// });



app.Run();
