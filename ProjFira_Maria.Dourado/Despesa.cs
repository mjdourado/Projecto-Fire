using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace ProjFira_Maria.Dourado;

public class Despesa
{
    public DateTime data { get; set; }
    public string categoria { get; set; }
    public string subcategoria { get; set; }
    public string beneficiario { get; set; }
    public string descricao { get; set; }
    public decimal valor { get; set; }
}
