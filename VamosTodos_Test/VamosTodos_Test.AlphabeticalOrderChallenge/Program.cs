// See https://aka.ms/new-console-template for more information

using System.Text;

Console.WriteLine("Ingrese una frase:");
string frase = Console.ReadLine();

string resultado = OrdenarFrase(frase!);
Console.WriteLine("Resultado: " + resultado);

static string OrdenarFrase(string frase)
{
	string[] fraseArray = frase.Split(" ");  
	
	// Convertir la cadena en un array de caracteres
	char[] characters = frase.ToCharArray();

	// Ordenar los caracteres alfabéticamente
	Array.Sort(characters, (x, y) => char.ToLower(x).CompareTo(char.ToLower(y)));
	char space = ' ';
	characters = Array.FindAll(characters, c => c != space);
	
	// Reconstruir la cadena ordenada
	string sortedString = new string(characters);

	int spaceLengCount = 0;
	for (int i = 0; i < fraseArray.Length - 1; i++)
	{
		
		spaceLengCount += fraseArray[i].Length;
		sortedString = addChar(sortedString, space, spaceLengCount);
		spaceLengCount++;
	}

	return sortedString;
}

static string addChar(String str, char ch, int position)
{
	StringBuilder sb = new StringBuilder(str);
	sb.Insert(position, ch);
	return sb.ToString();
}
