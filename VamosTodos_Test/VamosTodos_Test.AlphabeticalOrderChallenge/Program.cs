// See https://aka.ms/new-console-template for more information

Console.WriteLine("Ingrese una frase:");
string frase = Console.ReadLine();

string resultado = OrdenarLetrasEnPalabras(frase);
Console.WriteLine("Resultado: " + resultado);

static string OrdenarLetrasEnPalabras(string frase)
{
    string[] palabras = frase.Split(' ');

    for (int i = 0; i < palabras.Length; i++)
    {
        palabras[i] = OrdenarPalabra(palabras[i]);
    }

    return string.Join(" ", palabras);
}

static string OrdenarPalabra(string palabra)
{
    char[] letras = palabra.ToCharArray();
    Array.Sort(letras, (x, y) => char.ToLower(x).CompareTo(char.ToLower(y)));
    return new string(letras);
}