using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjFira_Maria.Dourado;

public static class Configuracoes
{
    static DirectoryInfo baseDir;
    static List<Categoria> categorias = new List<Categoria>();
    static string _directoriaBase = "C:\\Fire\\Admin\\directoriabase.txt";
    static string _categoriasdirectory = "C:\\Fire\\Admin\\categoriasbase.txt";

    static string categoriasPath;

    public static DirectoryInfo BaseDir { get => baseDir; set => baseDir = value; }

    public static void IniciarConfiguracoes()
    {
        if (File.Exists(_directoriaBase))
        {
            baseDir = new DirectoryInfo(
                File.ReadAllLines(_directoriaBase)[0]
                );
        }
        if (File.Exists(_categoriasdirectory))
        {
            categoriasPath = File.ReadAllLines(_categoriasdirectory)[0];
            categorias = Categoria.ProcessarFicheiroCategorias(categoriasPath);
        }
    }

    public static void DirectoriaPathFile(string pastaBase)
    {
        var filePath = new FileInfo(_directoriaBase);
        File.WriteAllText(_directoriaBase, pastaBase);
    }

    public static void SetCategories(string path, List<Categoria> listaCategorias)
    {
        categorias = listaCategorias;
        categoriasPath = path;
        File.WriteAllText(_categoriasdirectory, path);
    }
}


