//Matriz de n x n
Console.WriteLine("Ingrese el número de filas:");
int filas = int.Parse(Console.ReadLine());

Console.WriteLine("Ingrese el número de columnas:");
int columnas = int.Parse(Console.ReadLine());

int[,] matriz = new int[filas,columnas];

for (int i = 0; i < filas; i++)
{
    for (int j = 0; j < columnas; j++)
    {
        Console.Write("Ingrese valor para [" + i + "," + j + "]: ");
        matriz[i, j] = int.Parse(Console.ReadLine());
    }
    Console.WriteLine("===========================================>");
}

 Console.WriteLine("===============Matriz Diseño===================>");

Console.WriteLine("Matriz:");
for (int i = 0; i < filas; i++)
{
    for (int j = 0; j < columnas; j++)
    {
        Console.Write(matriz[i, j] + " ");
    }
    Console.WriteLine();
}
