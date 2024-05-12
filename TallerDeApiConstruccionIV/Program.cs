using Microsoft.EntityFrameworkCore;
using TodoApi.src.Config;
using TodoApi.src.Entities;
using TodoApi.src.Handler;
using TodoApi.src.ValidacionDeSusPropiedades;


var Constructor = WebApplication.CreateBuilder(args);
Constructor.Services.AddDbContext<DbMemory>(opt => opt.UseInMemoryDatabase("TodoList"));
Constructor.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = Constructor.Build();

// 1 --> Crear un solo pokemon
app.MapPost("/post/pokemon/solouno", async (HttpContext context, DbMemory db) =>
{
    try
    {
        Todo? todo = await context.Request.ReadFromJsonAsync<Todo>();
        
        if (todo == null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Se encuentra vacio");
            return;
        }

        CrearUnSoloPokemonPOST handler = new CrearUnSoloPokemonPOST(db);
        await handler.HandleAsync(todo);
        
        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsync("El Pokemon fue creado con exito");
    }
    catch (Exception e)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync(e.Message);
        return;
    }
});

//2 --> Crear varios pokemones
app.MapPost("/post/pokemones/masdeuno", async (HttpContext context, DbMemory db) =>
{
    try
    {
        var todos = await context.Request.ReadFromJsonAsync<List<Todo>>();

        if (todos == null || todos.Any(todo => todo == null || !new ValidarPropiedades(todo).ValidarP()))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Se encuentra vacio");
            return;
        }

        var handler = new CrearVariosPokemonesPOST(db);
        await handler.HandleAsync(todos);

        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsync("Los Pokemones fueron creados con exito");
    }
    catch (Exception e)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync(e.Message);
    }
});

// 3--> Modificar un pokemon
app.MapPut("/put/pokemon/{ID:int}", async (int ID, HttpContext context, DbMemory db) =>
{
    try
    {
        var todoUpdate = await context.Request.ReadFromJsonAsync<Todo>();

        if (todoUpdate == null || !new ValidarPropiedades(todoUpdate).ValidarP())
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Se encuentra vacio");
            return;
        }

        var put = new ModificarUnPokemonPUT(db, todoUpdate, ID);
        await put.Handler();

        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsync("Pokemon ha sido actualizado con exito");
    }
    catch (Exception e)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync(e.Message);
    }
});


// 4--> Eliminar un pokemon
app.MapDelete("/delete/pokemon/{ID:int}", async (int ID, HttpContext context, DbMemory db) =>
{
    try
    {
        await new EliinarUnPokemonEnEspecificoDELETE(db, ID).Delete();
        return Results.Ok("Pokemon eliminado con exito");
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message);
    }
});


// 5--> Mostrar un pokemon en especifico 
app.MapGet("/get/pokemon/unosolo/{ID:int}", async (int ID, HttpContext context) =>
{
    try
    {
        DbMemory db = context.RequestServices.GetRequiredService<DbMemory>();
        MostrarUnSoloPokemonGET handle = new MostrarUnSoloPokemonGET(db, ID);
        var todos = handle.Handle();
        return Results.Ok(todos);
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message);
    }
});
// 6--> Moatrar todos los pokemones de su mismo tipo
app.MapGet("/get/pokemon/tipo/{type}", async (string type, HttpContext context) =>
{
    try
    {
        DbMemory db = context.RequestServices.GetRequiredService<DbMemory>();
        MostrarTodosLosPokemonesDeSuTipoGET handle = new MostrarTodosLosPokemonesDeSuTipoGET(db, type);
        var todos = handle.Handle();
        return Results.Ok(todos);
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message);
    }
});

// 7--> Mostrar todos los pokemones
app.MapGet("/get/pokemon/todos", async (HttpContext context) =>
{
    try
    {
        DbMemory db = context.RequestServices.GetRequiredService<DbMemory>();
        MostrarTodosLosPokemones handler = new MostrarTodosLosPokemones(db);
        var todos = handler.Handle().ToList(); 
        return Results.Ok(todos);
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message);
    }
});

// 8 --> Eliminar todos los pokemones
app.MapDelete("/delete/pokemon/todos", async (HttpContext context, DbMemory db) =>
{
    try
    {
        var handler = new EliminarTodosLosPokemonesDELETE(db);
        await handler.Delete();
        return Results.Ok("Todos los pokemones han sido eliminados con exito");
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message);
    }
});

app.Run();
