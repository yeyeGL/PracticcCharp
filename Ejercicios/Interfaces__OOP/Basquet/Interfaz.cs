public interface IJugador
{
    string Nombre();
    int Rendimiento();
}

public class Jugador : IJugador
{
    private string nombre;
    private int rendimiento;
    public Jugador(string nombre)
    {
        this.nombre = nombre;
        this.rendimiento = new Random().Next(1, 11);
    }
    public string Nombre()
    {
        return nombre;
    }

    public int Rendimiento()
    {
        return rendimiento;
    }
}
public class Equipo
{
    private string nombre;
    private List<IJugador> jugadores;

    public Equipo(string nombre)
    {
        this.nombre = nombre;
        this.jugadores = new List<IJugador>();
    }

    public void AggJugador(IJugador jugador)
    {
        jugadores.Add(jugador);
    }
    public int SumaDeRendimiento()
    {
        int totalR = 0;
        foreach (var jugador in jugadores)
        {
            totalR = totalR + jugador.Rendimiento();
        }
        return totalR;
    }
    public void JugadoresDeCadaEquipo()
    {
        foreach (var jugador in jugadores)
        {
            Console.WriteLine($"Nombre: {jugador.Nombre()}= Rendimiento: {jugador.Rendimiento()}");
        }
    }
}