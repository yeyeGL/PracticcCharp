//Vector simple

int[] vector1 = new int[5];

vector1[0] = 10;
vector1[1] = 20;
vector1[2] = 30;
vector1[3] = 40;
vector1[4] = 50;

for (int i = 0; i < vector1.Length; i++)
{
    Console.WriteLine(vector1[i]);
}

//Vector pero se ingresan por consola

int[] vector2 = new int[5];

for (int i = 0; i < vector2.Length; i++)
{
    Console.Write($"Ingrese elemento {i + 1}: ");
    vector2[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Los elementos del arreglo son:");
for (int i = 0; i < vector2.Length; i++)
{
    Console.WriteLine(vector2[i]);
}

//Vector con numeros aleatorios

Random r = new Random();

int[] vector3 = new int[5];

for (int i = 0; i < vector3.Length; i++)
{
    vector3[i] = r.Next(1, 11);
}

Console.WriteLine("Vector con numeros al azar son:");
for (int i = 0; i < vector3.Length; i++)
{
    Console.Write($"{vector3[i]} ");
}
Console.WriteLine();

//Numeros repetidos de un arreglo y en que posocion

int[] vector4 = new int[5];
bool numerosrepetidos = false;

for (int i = 0; i < vector4.Length; i++)
{
    Console.Write($"Ingrese elemento {i + 1}: ");
    vector4[i] = int.Parse(Console.ReadLine());
}

for (int i = 0; i < vector4.Length; i++)
{
    for (int j = i + 1; j < vector4.Length; j++)
    {
        if (vector4[i] == vector4[j])
        {
            Console.WriteLine($"Número igual encontrado: {vector4[i]} en las posiciones {i} y {j}");
            numerosrepetidos = true;
        }
    }
}
if (!numerosrepetidos)
{
    Console.WriteLine("No hay numeros repetidos");
}
