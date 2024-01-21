using ProjFira_Maria.Dourado;
using System.Reflection;

public class Categoria
{
    public string Nome { get; set; }
    public List<string> Subcategorias { get; set; }

    public Categoria()
    {
        Subcategorias = new List<string>();
    }

    public void DefinirCategorias()
    {

        Console.WriteLine("Indique o caminho do ficheiro que contem as categorias e subcategorias que deseja importar");
        string path = Console.ReadLine();
        var categorias = ProcessarFicheiroCategorias(path);
        Configuracoes.SetCategories(path, categorias);
    }

    public static List<Categoria> ProcessarFicheiroCategorias (string path)
    {
        List<Categoria> categorias = new List<Categoria>();
        Categoria categoriaActual = null;
        string[] linhas = File.ReadAllLines(path);
        try
        {
            foreach( var linha in linhas  )
            {
                if (linha is not null)
                {
                    if (linha.StartsWith('\t'))
                    {
                        categoriaActual.Subcategorias.Add(linha.Trim());
                    }
                    else
                    {
                        categoriaActual = new Categoria { Nome = linha };
                        categorias.Add(categoriaActual);
                    }
                }
            }
            categorias.Add(new Categoria { Nome = "Others" });
        }
        catch (Exception ex) { Console.WriteLine("Erro a processar ficheiro");
        categorias = new List<Categoria> { new Categoria { Nome = "Others" } };
            
        }

        return categorias;
    }
}