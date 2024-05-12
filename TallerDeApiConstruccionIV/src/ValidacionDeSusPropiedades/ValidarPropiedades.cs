using TodoApi.src.Config;
using TodoApi.src.Entities;

namespace TodoApi.src.ValidacionDeSusPropiedades;

public class ValidarPropiedades{
    private Todo _todo;

    internal ValidarPropiedades(Todo todo){
        this._todo = todo;
    }

    public bool ValidarP(){
        if (string.IsNullOrWhiteSpace(this._todo.Nombre))
            return false;

        foreach (var habilidades in this._todo.ArrayAtaques)
        {
            if (habilidades < 0 || habilidades > 40)
                return false;
        }

        if (this._todo.ArrayAtaques.Count > 4)
            return false;

        if (this._todo.ArrayAtaques.Count == 0)
            return false;

        if (this._todo.Defensa > 30 || this._todo.Defensa < 1)
            return false;

        return true; 

    }

    public string isValidMessage(){
        if (string.IsNullOrWhiteSpace(this._todo.Nombre))
            return "El campo de nombre no puede estar vacio";

        foreach (var habilidades in this._todo.ArrayAtaques)
        {
            if (habilidades < 0 || habilidades > 40)
                return "Los puntos de ataque de los pokemones deben de estar entre 0 y 40";
        }

        if (this._todo.ArrayAtaques.Count > 4)
            return "Maximo 4 ataques";

        if (this._todo.ArrayAtaques.Count == 0)
            return "Debe tener por lo menos un ataque";

        if (this._todo.Defensa > 30 || this._todo.Defensa < 1)
            return "La defensa debe de estar entre los puntos 1 y 30";
        return ""; 
    }
}