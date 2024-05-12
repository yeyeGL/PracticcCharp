Console.WriteLine("Ingrese el numero cual quiere que se invierta");
int numeroAinvertir1 = int.Parse(Console.ReadLine());

int invertido1 = 0;
while (numeroAinvertir1 > 0)
{
    int resto = numeroAinvertir1 % 10;
    invertido1 = invertido1 * 10 + resto;
    numeroAinvertir1 = numeroAinvertir1 / 10;
}

Console.WriteLine($"El numero invertido de :{numeroAinvertir1} es: " + invertido1);

//Numero invertido pasando de entero a una cadena

Console.WriteLine("Introduzca un numero el cual quiere invertir: ");
int numeroAinvertir2 = int.Parse(Console.ReadLine());

string cadena = numeroAinvertir2.ToString();

int invertido2 = 0;
for (int i = cadena.Length - 1; i >= 0; i--)
{
    invertido2 = invertido2 * 10 + (cadena[i] - '0');
}

Console.WriteLine("El numero invertido es: " + invertido2);
