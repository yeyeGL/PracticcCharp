public class Basquet
{
    private List<IJugador> jugadoresDisponibles;
    private Equipo Local;
    private Equipo Visitante;

    public Basquet()
    {
        jugadoresDisponibles = new List<IJugador>
        {
            new Jugador("Lebron James"),
            new Jugador("Stephen Curry"),
            new Jugador("Kevin Durant"),
            new Jugador("Michael Jordan 23"),
            new Jugador("Jason Tatum"),
            new Jugador("James Harden"),
            new Jugador("Luka Doncic"),
            new Jugador("Anthony Davis"),
            new Jugador("Joel Embiid"),
            new Jugador("Nikola Jokic")
        };

        Local = new Equipo("Local");
        Visitante = new Equipo("Visitante");
    }

    public void RepartirJugadores()
    {
        Random rr = new Random();
        for (int i = 0; i < 6; i++)
        {
            int recorrido = rr.Next(jugadoresDisponibles.Count);
            IJugador JugarRepartido = jugadoresDisponibles[recorrido];
            jugadoresDisponibles.RemoveAt(recorrido);

            if (i % 2 == 0)
            {
                Local.AggJugador(JugarRepartido);
            }
            else
            {
                Visitante.AggJugador(JugarRepartido);
            }
        }
        Console.WriteLine("Jugadores repartidos correctamente");
    }

    public void DecidirGanador()
    {
        Console.WriteLine("===================Resultados====================");
        Console.WriteLine("");
        int Sumadelocal = Local.SumaDeRendimiento();
        int SumaVisitante = Visitante.SumaDeRendimiento();

        Console.WriteLine($"Rendimiento total del equipo local: {Local.SumaDeRendimiento()}");
        Console.WriteLine($"Rendimiento total del equipo visitante: {Visitante.SumaDeRendimiento()}");

        if (Sumadelocal > SumaVisitante)
        {
            Console.WriteLine("El equipo local gana con un rendimiento total de: " + Sumadelocal);
            Console.WriteLine("________________________________________");
        }
        else if (SumaVisitante > Sumadelocal)
        {
            Console.WriteLine("El equipo visitante gana con un rendimiento total de: " + SumaVisitante);
            
        }
        else
        {
            Console.WriteLine("El partido quedo en empatado");
        }

        
    }

    public void AggJugador()
    {
        Console.WriteLine("Ingrese el nombre del jugador a agregar:");
        string nombre = Console.ReadLine();
        jugadoresDisponibles.Add(new Jugador(nombre));
        Console.WriteLine($"Jugador {nombre} agregado a la lista ");
    }

    public void VerJugadoresDisponibles()


    {
        Console.WriteLine("_________________________");
        Console.WriteLine("Jugadores disponibles:");
        Console.WriteLine("_________________________");
        foreach (var jugador in jugadoresDisponibles)
        {
            Console.WriteLine(jugador.Nombre());
        }
    }

    public void VerJugadoresSeleccionados()
    {
        Console.WriteLine("");
        Console.WriteLine("=====================Local==================");
        Console.WriteLine("");
        Local.JugadoresDeCadaEquipo();
        Console.WriteLine("");
        Console.WriteLine("===================Visitante================");
        Console.WriteLine("");
        Visitante.JugadoresDeCadaEquipo();
         Console.WriteLine("");
    }

    public void MenuPartido()
    {
        int opcion;
        do
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1 --> Repartirr jugadores");
            Console.WriteLine("2 --> Ver jugadores seleccionados ");
            Console.WriteLine("3 --> Ver jugadores disponibles");
            Console.WriteLine("4 --> Agregar un nuevo jugador a la lista");
            Console.WriteLine("5 --> Decidir ganador");
            Console.WriteLine("6 --> Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RepartirJugadores();
                    break;
                case 2:
                    VerJugadoresSeleccionados();
                    break;
                case 3:
                    VerJugadoresDisponibles();
                    break;
                case 4:
                    AggJugador();
                    break;
                case 5:
                    DecidirGanador();
                    break;
                case 6:
                    Console.WriteLine("Saliendo....");
                    break;

                default:
                    Console.WriteLine("Opcion no valida de nuevo la opcion");
                    break;
            }
        } while (opcion != 6);
    }
}
