using System;

int opcionSeleccionada;

do
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("***************************");
    Console.WriteLine("   Menú de Ejercicios   ");
    Console.WriteLine("***************************");
    Console.ResetColor();

    Console.WriteLine("1. Calculadora Básica");
    Console.WriteLine("2. Validación de Contraseña");
    Console.WriteLine("3. Verificar Número Primo");
    Console.WriteLine("4. Sumar Números Pares");
    Console.WriteLine("5. Convertir Temperatura");
    Console.WriteLine("6. Contar Vocales");
    Console.WriteLine("7. Calcular Factorial");
    Console.WriteLine("8. Juego de Adivinanzas");
    Console.WriteLine("9. Paso por Referencia");
    Console.WriteLine("10. Tabla de Multiplicar");
    Console.WriteLine("0. Salir");
    Console.Write("Elige una opción: ");

    Console.ForegroundColor = ConsoleColor.Yellow;

    if (int.TryParse(Console.ReadLine(), out opcionSeleccionada))
    {
        switch (opcionSeleccionada)
        {
            case 1:
                EjecutarCalculadora();
                break;
            case 2:
                ValidarContraseña();
                break;
            case 3:
                VerificarPrimo();
                break;
            case 4:
                SumarNumerosPares();
                break;
            case 5:
                ConvertirTemperatura();
                break;
            case 6:
                ContarVocales();
                break;
            case 7:
                CalcularFactorial();
                break;
            case 8:
                JugarAdivinanzas();
                break;
            case 9:
                RealizarPasoPorReferencia();
                break;
            case 10:
                MostrarTablaMultiplicar();
                break;
            case 0:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Saliendo...");
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opción inválida. Te invitamos a que intentes de nuevo :D");
                break;
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ingresa un número válido.");
    }

    Console.ResetColor();
    Console.WriteLine("\nPresiona una tecla para continuar...");
    Console.ReadKey();

} while (opcionSeleccionada != 0);

static void EjecutarCalculadora()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Ingresa el primer número: ");
    if (!double.TryParse(Console.ReadLine(), out double primerNumero))
    {
        Console.WriteLine("Número no aceptado/inválido.");
        return;
    }

    Console.WriteLine("Ingresa el segundo número: ");
    if (!double.TryParse(Console.ReadLine(), out double segundoNumero))
    {
        Console.WriteLine("Número no aceptado/inválido.");
        return;
    }

    Console.WriteLine("Elige la operación que deseas realizar: +, -, *, /");
    string operacionSeleccionada = Console.ReadLine() ?? string.Empty;

    double resultado = operacionSeleccionada switch
    {
        "+" => primerNumero + segundoNumero,
        "-" => primerNumero - segundoNumero,
        "*" => primerNumero * segundoNumero,
        "/" => segundoNumero != 0 ? primerNumero / segundoNumero : double.NaN,
        _ => double.NaN
    };

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Resultado: {resultado}");
}

static void ValidarContraseña()
{
    string contraseña;
    do
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Ingresa la contraseña: ");
        contraseña = Console.ReadLine() ?? string.Empty;
    } while (contraseña != "jesús");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Acceso concedido.");
}

static void VerificarPrimo()
{
    Console.WriteLine("Ingresa un número: ");
    if (int.TryParse(Console.ReadLine(), out int numero))
    {
        bool esPrimo = EsNumeroPrimo(numero);
        Console.WriteLine(esPrimo ? "El número que ingresaste es primo" : "El número que ingresaste no es primo");
    }
    else
    {
        Console.WriteLine("Número inválido.");
    }
}

static bool EsNumeroPrimo(int numero)
{
    if (numero < 2) return false;
    for (int i = 2; i * i <= numero; i++)
    {
        if (numero % i == 0) return false;
    }
    return true;
}

static void SumarNumerosPares()
{
    int sumaPares = 0, numero;
    do
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Ingresa un número (1 para salir): ");
        if (int.TryParse(Console.ReadLine(), out numero) && numero % 2 == 1)
        {
            sumaPares += numero;
        }
    } while (numero != 1);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"La suma de los números pares es: {sumaPares}");
}

static void ConvertirTemperatura()
{
    Console.WriteLine("Ingresa la temperatura: ");
    if (!double.TryParse(Console.ReadLine(), out double temperatura))
    {
        Console.WriteLine("Número inválido.");
        return;
    }

    Console.WriteLine("Elige una opción: A para Celsius a Fahrenheit o B para Fahrenheit a Celsius");
    string opcion = Console.ReadLine()?.ToUpper() ?? string.Empty;

    double temperaturaConvertida = opcion switch
    {
        "A" => (temperatura * 9 / 5) + 32,
        "B" => (temperatura - 32) * 5 / 9,
        _ => double.NaN
    };

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Temperatura convertida: {temperaturaConvertida}");
}

static void ContarVocales()
{
    Console.WriteLine("Ingresa una frase: ");
    string frase = Console.ReadLine()?.ToLower() ?? string.Empty;
    int cantidadVocales = 0;

    foreach (char caracter in frase)
    {
        if ("aeiou".Contains(caracter)) cantidadVocales++;
    }

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"La cantidad de vocales es: {cantidadVocales}");
}

static void CalcularFactorial()
{
    Console.Write("Ingresa un número: ");
    if (int.TryParse(Console.ReadLine(), out int numero))
    {
        long factorial = 1;
        for (int i = 1; i <= numero; i++)
        {
            factorial *= i;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"El factorial de {numero} es: {factorial}");
    }
    else
    {
        Console.WriteLine("Número inválido.");
    }
}

static void JugarAdivinanzas()
{
    Random random = new Random();
    int numeroSecreto = random.Next(1, 101), intento;
    Console.WriteLine("Adivina el número secreto (1-100)");

    do
    {
        Console.WriteLine("Ingresa un número: ");
        if (int.TryParse(Console.ReadLine(), out intento))
        {
            if (intento < numeroSecreto) Console.WriteLine("Fue demasiado bajo tu intento.");
            else if (intento > numeroSecreto) Console.WriteLine("Fue demasiado alto tu intento.");
        }
    } while (intento != numeroSecreto);

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("¡Adivinaste el número!");
}

static void RealizarPasoPorReferencia()
{
    Console.Write("Ingresa el primer número: ");
    if (!int.TryParse(Console.ReadLine(), out int numero1))
    {
        Console.WriteLine("Número inválido.");
        return;
    }

    Console.Write("Ingresa el segundo número: ");
    if (!int.TryParse(Console.ReadLine(), out int numero2))
    {
        Console.WriteLine("Número inválido.");
        return;
    }

    IntercambiarValores(ref numero1, ref numero2);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Valores intercambiados: {numero1}, {numero2}");
}

static void IntercambiarValores(ref int a, ref int b)
{
    int temporal = a;
    a = b;
    b = temporal;
}

static void MostrarTablaMultiplicar()
{
    Console.Write("Ingresa un número: ");
    if (int.TryParse(Console.ReadLine(), out int numero))
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{numero} x {i} = {numero * i}");
        }
    }
    else
    {
        Console.WriteLine("Número inválido.");
    }
}
