namespace TodoApi.src.Handler;
using Microsoft.AspNetCore.Mvc;
using TodoApi.src.Config;
using TodoApi.src.Entities;

public class EliinarUnPokemonEnEspecificoDELETE{
    private DbMemory _db;
    private int _id;
    internal EliinarUnPokemonEnEspecificoDELETE(DbMemory db,int id){
        this._db = db;
        this._id = id;
    }

    public async Task<IActionResult> Delete(){
        var todo = this._db.Todos.FirstOrDefault(
        item => item.Id == this._id
        );
        if(todo == null){
            throw new ArgumentException($"El pokemon con el id {this._id} no existe");
        }
        this._db.Todos.Remove(todo);
        await this._db.SaveChangesAsync();
        return new OkResult();
    }
}