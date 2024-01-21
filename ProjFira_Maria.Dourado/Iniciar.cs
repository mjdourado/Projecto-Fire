namespace ProjFira_Maria.Dourado;

public class Iniciar
{

    private string _userName = "admin";
    private string _password = "TcGf3o#23";
    private string _pastaBase;

    private string GetFilePath() => Path.Combine("C:\\Fire\\Admin", "InfoAdmin");

    public void MensagemInicial()
    {
        var ficheiro = new FileInfo(GetFilePath());
        if (ficheiro.Exists)
        {
            Menus novo = new Menus();
            novo.MenuGeral();
        } else
        {
            Console.WriteLine("Necessário login do administrador e definição de directoria base");
            Autenticar();
        }
    }

    public void Autenticar()
    {
        Console.WriteLine("Insira o nome de utilizador");
        string username = Console.ReadLine();
        Console.WriteLine("Insira a palavra pass");
        string password = Console.ReadLine();
        Validar(username, password);
    }

    public void Validar(string user, string pwd)
    {
        if (user == _userName && pwd == _password)
        {
            CriarFicheiroAdmin();
            SetUsernameAndPwd(_userName, _password);
            Menus novo = new Menus();
            novo.Administrador();
            return;
        }
        else
        {
            Console.WriteLine("Credenciais incorrectas, por favor,tente novamente");
            Autenticar();
        }
    }

    public void CriarFicheiroAdmin()
    {
        var dir = new DirectoryInfo("C:\\Fire\\Admin");
        if (!dir.Exists)
            dir.Create();
    }

    public void SetUsernameAndPwd(string username, string pwd)
    {
        string[] credentials = [username, pwd];
        File.WriteAllLines(GetFilePath(), credentials);
    }

    public void DefinirDirectoriaBase()
    {
        Console.WriteLine("Insira o caminho da directoria base");
        _pastaBase = Console.ReadLine();
        CriarPasta();
    }

    public void CriarPasta() 
    {
        var dir = new DirectoryInfo(_pastaBase);
        if (!dir.Exists)
        {
            dir.Create();
        }
        Configuracoes.BaseDir = dir;
        Configuracoes.DirectoriaPathFile(_pastaBase);
    }

}
