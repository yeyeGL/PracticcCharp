namespace TodoApi.src.Handler;
using Microsoft.AspNetCore.Mvc;
using TodoApi.src.Config;
using TodoApi.src.Entities;

public class MostrarTodosLosPokemonesDeSuTipoGET
{
    private DbMemory _db;
    private string Tipo;

    internal MostrarTodosLosPokemonesDeSuTipoGET(DbMemory db, string Tipo)
    {
        this._db = db;
        this.Tipo = Tipo;
    }
    public IEnumerable<Todo> Handle()
    {
        var todos = this._db.Todos.Where(item => item.Tipo == this.Tipo).ToList();
        return todos;
    }
}