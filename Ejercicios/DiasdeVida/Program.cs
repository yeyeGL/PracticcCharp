Console.WriteLine("Ingrese su edad por favor");

int edad = int.Parse(Console.ReadLine());

int añobisiesto = (edad / 4);
int año = 365;
int semana = 7;

int Diastotales = (edad * año + añobisiesto);
int SemanasTotales = (Diastotales / semana );

Console.WriteLine("Los dias totales de tu vida segun tu edad es --> "+Diastotales);
Console.WriteLine("Las semanas totales de tu vida segun tu edad es --> "+SemanasTotales);
