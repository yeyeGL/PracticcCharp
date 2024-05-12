namespace TodoApi.src.Handler;
using Microsoft.AspNetCore.Mvc;
using TodoApi.src.Config;
using TodoApi.src.Entities;

public class ModificarUnPokemonPUT{
    private DbMemory _db;
    private Todo _actualizarTodo;
    private int id;

    internal ModificarUnPokemonPUT(DbMemory db, Todo actualizarTodo, int id){
        this._db = db;
        this._actualizarTodo = actualizarTodo;
        this.id = id;
    }

    public async Task<IActionResult> Handler(){
        var todo = this._db.Todos.FirstOrDefault(
        item => item.Id == this.id
        );
        if (todo == null){
            throw new ArgumentException($"El pokemon con el id {this.id} no existe  ");
        }
        this._db.Entry(todo).CurrentValues.SetValues(this._actualizarTodo);
        await this._db.SaveChangesAsync();
        return new OkResult();
    }
}