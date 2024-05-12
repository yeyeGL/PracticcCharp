namespace TodoApi.src.Entities;
using System.ComponentModel.DataAnnotations;

public class Todo
{
    public int Id { get; set; }
    
    public string Nombre { get; set; }

    public string Tipo { get; set; }
    public List<int> ArrayAtaques { get; set; } = new List<int>();
    public float Defensa { get; set; }
}
