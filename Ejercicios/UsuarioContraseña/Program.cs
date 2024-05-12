
string usuarioP = "admin";
string contrasenaP = "12345";

int intentosRestantes = 3;

while (intentosRestantes > 0)
{

    Console.WriteLine("Ingrese su nombre de usuario:");
    string usuarioIngresado = Console.ReadLine();
    Console.WriteLine("Ingrese su contraseña:");
    string contrasenaIngresada = Console.ReadLine();
   
    if (usuarioIngresado == usuarioP && contrasenaIngresada == contrasenaP)
    {
        
        Console.WriteLine("Acceso concedido ");
        break;
    }
    else
    {
        intentosRestantes--;
        Console.WriteLine("Nombre de usuario o contraseña incorrectos los intentos que le quedan son: " + intentosRestantes);
    }
}

if (intentosRestantes == 0)
{
    Console.WriteLine("Acceso denegado se agotaron los intentos");
}

