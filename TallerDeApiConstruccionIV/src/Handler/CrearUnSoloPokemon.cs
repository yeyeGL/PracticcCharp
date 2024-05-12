namespace TodoApi.src.Handler;
using Microsoft.AspNetCore.Mvc;
using TodoApi.src.Config;
using TodoApi.src.Entities;

public class CrearUnSoloPokemonPOST
{
    private DbMemory _db;

    internal CrearUnSoloPokemonPOST(DbMemory db)
    {
        this._db = db;
    }

    public async Task<IActionResult> HandleAsync(Todo todo)
    {
        this._db.Todos.Add(todo);
        await this._db.SaveChangesAsync();
        return new CreatedResult($"/api/v1/Todo/{todo.Id}", todo);
    }
}