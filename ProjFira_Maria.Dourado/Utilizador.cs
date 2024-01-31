using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjFira_Maria.Dourado;

public class Utilizador
{

    public string _nomeUtilizador { get; set; }
    public string _password { get; set; }
    public string nome { get; set; }
    public DateOnly dataNascimento { get; set; }
    public float patrimnio { get; set; }
    public float mediaDespesas { get; set; }
    public float retorno { get; set; }
    public float inflacao { get; set; }
    public int longevidade { get; set; }
    public string dirBase { get; set; } = File.ReadAllText("C:\\Fire\\Admin\\directoriabase.txt");

    public string jsonFile()
    {
        string jsonfilePath = Path.Combine(Configuracoes.BaseDir.FullName, _nomeUtilizador + ".json");
        return jsonfilePath;
    }
    public string GetFilePath()
    {
        string filePath = Path.Combine(dirBase, _nomeUtilizador);
        return filePath;
    }

    public void NovoUtilizador()
    {
        Console.WriteLine("Insira um novo utilizador até quinza (15) caracteres");
        _nomeUtilizador = Console.ReadLine();
        if (_nomeUtilizador.Length > 15)
        {
            Console.WriteLine("Nome de Utilizador Inválido. Tente novamente!");
        }
        else
        {
            NovaPassword();
        }
    }

    public void NovaPassword()
    {
        Console.WriteLine("Insira uma password até oito (8) caracteres");
        _password = Console.ReadLine();
        if (_password.Length > 8)
        {
            Console.WriteLine("Password inválida. Tente novamente!");
            NovaPassword();
        }
        else
        {
            CriarFicheiroUtilizador();
        }
    }

    public void CompletarDados()
    {
        Console.WriteLine("Insira o seu nome");
        nome = Console.ReadLine();
        Console.WriteLine("Insira a sua data de nascimento");
        dataNascimento = DateOnly.Parse(Console.ReadLine());
        Console.WriteLine("Insira o valor do seu património");
        patrimnio = float.Parse(Console.ReadLine());
        Console.WriteLine("Insira o valor médio das suas despesas mensais");
        mediaDespesas = float.Parse(Console.ReadLine());
        Console.WriteLine("Insira a taxa de retorno esperada");
        retorno = float.Parse(Console.ReadLine());
        Console.WriteLine("Insira o valor da inflação");
        inflacao = float.Parse(Console.ReadLine());
        Console.WriteLine("Insira a sua longevidade estimada");
        longevidade = Console2.ReadInt();
        userObject();
    }

    public void userObject()
    {
        Utilizador user = new Utilizador
        {
            _nomeUtilizador = _nomeUtilizador,
            _password = _password,
            nome = nome,
            dataNascimento = dataNascimento,
            patrimnio = patrimnio,
            mediaDespesas = mediaDespesas,
            retorno = retorno,
            inflacao = inflacao,
            longevidade = longevidade
        };
        var jsonUser = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(user, jsonUser);
        File.WriteAllText(jsonFile(), jsonString);
        Menus menu = new Menus();
        menu.Utilizador();
    }


    public void CriarFicheiroUtilizador()
    {
        var file = new FileInfo(GetFilePath());
        if (!file.Exists)
        {

            string[] credentials = [_nomeUtilizador, _password];
            File.WriteAllLines(GetFilePath(), credentials);
            CompletarDados();
        }
        else
        {
            Console.WriteLine("Utilizador já registado. Faça login ou escolha outro nome de utilizador.");
            NovoUtilizador();
        }
    }

    public void Autenticar()
    {
        Console.WriteLine("Insira o nome de utilizador");
        _nomeUtilizador = Console.ReadLine();
        Console.WriteLine("Insira a password");
        _password = Console.ReadLine();
        if (_nomeUtilizador == "admin" && _password == "TcGf3o#23")
        {
            Menus administrador = new Menus();
            administrador.Administrador();
        }
        else
        {
            Validar(_nomeUtilizador, _password);
        }
    }

    public void Validar(string username, string password)
    {
        var file = new FileInfo(GetFilePath());
        if (file.Exists)
        {
            var credenciais = File.ReadAllLines(GetFilePath());
            if (username == credenciais[0] && password == credenciais[1])
            {
                Console.WriteLine("Autenticado!");
                DefinirLogUser(username, jsonFile());
                Menus novo = new Menus();
                novo.Utilizador();
            }
            else
            {
                Console.WriteLine("Credenciais incorrectas, tente de novo!");
                Autenticar();
            }
        } else
        {
            Console.WriteLine("Utilizador não encontrado. Registe-se ou tente novamente");
            Menus novo = new Menus();
            novo.MenuGeral();
        }
    }

    public void Eliminar()
    {
        Console.WriteLine("Insira o nome de utilizador");
        _nomeUtilizador = Console.ReadLine();
        Console.WriteLine("Insira a password");
        _password = Console.ReadLine();
        File.Delete(Configuracoes.BaseDir + _nomeUtilizador);
        Console.WriteLine("Utilizador Eliminado com Sucesso");
    }

    public void DefinirLogUser(string username, string filePath)
    {
        Configuracoes._logUser = username;
        Configuracoes._logfile = filePath;
    }
}


