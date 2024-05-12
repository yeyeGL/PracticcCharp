namespace TodoApi.src.Handler;
using Microsoft.AspNetCore.Mvc;
using TodoApi.src.Config;
using TodoApi.src.Entities;


public class MostrarTodosLosPokemones
{
    private DbMemory _db;

    internal MostrarTodosLosPokemones(DbMemory db)
    {
        this._db = db;
    }

    public IQueryable<Todo> Handle()
    {
        return this._db.Todos.AsQueryable();
    }
}
