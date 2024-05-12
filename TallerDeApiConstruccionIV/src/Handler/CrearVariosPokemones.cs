namespace TodoApi.src.Handler;
using Microsoft.AspNetCore.Mvc;
using TodoApi.src.Config;
using TodoApi.src.Entities;

public class CrearVariosPokemonesPOST
{
    private DbMemory _db;

    internal CrearVariosPokemonesPOST(DbMemory db)
    {
        this._db = db;
    }

    public async Task<IActionResult> HandleAsync(IEnumerable<Todo> todos)
    {
        foreach (var todo in todos){
            this._db.Todos.Add(todo);
        }
        await this._db.SaveChangesAsync();
        var lastTodo = todos.LastOrDefault();
        return new CreatedResult($"/api/v1/Todo/{lastTodo?.Id}", todos);
    }
}