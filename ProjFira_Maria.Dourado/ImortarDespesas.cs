using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace ProjFira_Maria.Dourado;

internal class ImportarDespesas
{
    public void LerFicheiro()
    {
        Console.WriteLine("Insira o caminho para importar o ficheiro com as suas despesas");
        var reader = new StreamReader(Console.ReadLine());
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ";",
        };
        var csv = new CsvReader(reader, config);
        Despesa despesa = new Despesa();
        var despesas = csv.EnumerateRecords(despesa);
        Console.WriteLine("Para voltar ao menu anterior prima q");
        string userRequest = Console.ReadLine();
        if (userRequest == "q")
        {
            Menus menu = new Menus();
            menu.Utilizador();
        }
    }
}
