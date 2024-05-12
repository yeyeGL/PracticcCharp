
Random r = new Random();
int intentos = 3;
int numeror = (r.Next(1, 10));


do
{

    Console.WriteLine("Ingrese el numero que crees que es:");
    int numeroadivinar = int.Parse(Console.ReadLine());

    if (numeror > numeroadivinar)
    {
        Console.WriteLine("El numero debe ser mas alto");
    }
    else if (numeror < numeroadivinar)
    {
        Console.WriteLine("El numero debe ser mas bajo");
    }
    else if (numeror == numeroadivinar)
    {
        Console.WriteLine("Acertaste el numero era :" + numeror);
        break;
    }
    intentos = intentos - 1;
    Console.WriteLine("Te quedad " + intentos + " intentos");


} while (intentos > 0);

if (intentos == 0)
{
    Console.WriteLine("Perdiste el numero que tenias que adivinar es :" + numeror);
}
