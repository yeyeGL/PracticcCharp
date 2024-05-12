namespace Program
{
    class Fraccion
    {
        public int Numerador { get; set; }
        public int Denominador { get; set; }

        public Fraccion(int numerador, int denominador)
        {
            Numerador = numerador;
            Denominador = denominador;
        }

        public static Fraccion Sumar(Fraccion f1, Fraccion f2)
        {
            int comunDenominador = f1.Denominador * f2.Denominador;
            int numerador1 = f1.Numerador * f2.Denominador;
            int numerador2 = f2.Numerador * f1.Denominador;
            return new Fraccion(numerador1 + numerador2, comunDenominador);
        }

        public static Fraccion Restar(Fraccion f1, Fraccion f2)
        {
            int comunDenominador = f1.Denominador * f2.Denominador;
            int numerador1 = f1.Numerador * f2.Denominador;
            int numerador2 = f2.Numerador * f1.Denominador;
            return new Fraccion(numerador1 - numerador2, comunDenominador);
        }

        public static Fraccion Multiplicar(Fraccion f1, Fraccion f2)
        {
            return new Fraccion(f1.Numerador * f2.Numerador, f1.Denominador * f2.Denominador);
        }

        public static Fraccion Dividir(Fraccion f1, Fraccion f2)
        {
            if (f2.Numerador == 0)
            {
                throw new DivideByZeroException("No se puede dividir por cero");
            }
            return new Fraccion(f1.Numerador * f2.Denominador, f1.Denominador * f2.Numerador);
        }

        public override string ToString()
        {
            return $"{Numerador}/{Denominador}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int option;
            do
            {
                Console.WriteLine("--------------- MENU ---------------");
                Console.WriteLine("Seleccione las opciones del 1 al 2");
                Console.WriteLine("1. Calculadora de fracciones");
                Console.WriteLine("2. Salir");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("OPCIÓN: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Calculadora();
                        break;
                    case 2:

                        break;

                    default:
                        Console.WriteLine("OPCIÓN INCORRECTA!. INGRESE NUEVAMENTE UNA VALIDA");
                        break;
                }
            } while (option != 2);


        }

        //EJERCICIO 1: CALCULADORA DE FRACCIONES
        static void Calculadora()
        {
            try
            {
                int option;
                Console.WriteLine("Ingrese la primera fracción (EJ: Numerador/Denominador): ");
                string[] fra1 = Console.ReadLine().Split('/');
                int num1 = int.Parse(fra1[0]);
                int den1 = int.Parse(fra1[1]);



                Console.WriteLine("Ingrese la segunda fracción (EJ: Numerador/Denominador): ");
                string[] fra2 = Console.ReadLine().Split('/');
                int num2 = int.Parse(fra2[0]);
                int den2 = int.Parse(fra2[1]);
                do
                {
                    Console.WriteLine("¿Que operación desea realizar? Seleccione una opción.");
                    Console.WriteLine("1. Sumar");
                    Console.WriteLine("2. Restar");
                    Console.WriteLine("3. Multiplicar");
                    Console.WriteLine("4. Dividir");
                    Console.WriteLine("5. Salir");
                    Console.WriteLine("OPCION: ");
                    option = int.Parse(Console.ReadLine());

                    Fraccion f1 = new Fraccion(num1, den1);
                    Fraccion f2 = new Fraccion(num2, den2);
                    Fraccion resultado = null;
                    if (den1 == 0)
                    {
                        Console.WriteLine("El denominador no puede ser 0");
                        break;
                    }

                    if (den2 == 0)
                    {
                        Console.WriteLine("El denominador no puede ser 0");
                        break;
                    }

                    switch (option)
                    {
                        case 1:
                            resultado = Fraccion.Sumar(f1, f2);
                            break;
                        case 2:
                            resultado = Fraccion.Restar(f1, f2);
                            break;
                        case 3:
                            resultado = Fraccion.Multiplicar(f1, f2);
                            break;
                        case 4:
                            resultado = Fraccion.Dividir(f1, f2);
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("OPCIÓN NO VALIDA!. SELECCIONE UNA CORRECTA");
                            break;
                    }

                    if (resultado != null)
                    {
                        Console.WriteLine("El resultado es: {0}", resultado);
                    }
                } while (option != 5);

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("NO SE PUEDE DIVIDIR POR 0");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

    }
}