Console.WriteLine("Ingrese un numero por favor :");

int numero = int.Parse(Console.ReadLine());

if(numero % 5 == 0){
    if(numero % 2 != 0 && numero % 3 != 0){
        Console.WriteLine("El numero es especial ---> "+numero);
    } else {
        Console.WriteLine("El numero no es especial ---> "+numero);
    }
} else {
    Console.WriteLine("El numero no es divisible entre 5 ---> "+numero);
}