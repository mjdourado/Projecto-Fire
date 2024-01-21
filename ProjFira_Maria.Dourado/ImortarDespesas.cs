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
        foreach( var desp in despesas )
        {

        }
    }
}
