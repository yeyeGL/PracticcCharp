namespace TodoApi.src.Handler;
using Microsoft.AspNetCore.Mvc;
using TodoApi.src.Config;
using TodoApi.src.Entities;

public class EliminarTodosLosPokemonesDELETE{
    private DbMemory _db;
    
    internal EliminarTodosLosPokemonesDELETE(DbMemory db){
        this._db = db;
    }

    public async Task<IActionResult> Delete(){
        var todos = this._db.Todos.ToList();
        if(todos.Count == 0){
            return new NoContentResult();
        }
        
        foreach(var todo in todos){
            this._db.Todos.Remove(todo);
        }
        
        await this._db.SaveChangesAsync();
        return new OkResult();
    }
}
