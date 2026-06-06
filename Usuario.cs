public class Usuario
{
    public string nome;
    public string dataNasc;
    public string email;
    private string _senha;
    private List<Perfil> _listaPerfis = new List<Perfil>();

    public string Senha
    {
        get => _senha;
        set
        {
            if (value.Length < 6)
                throw new Exception("Senha muito curta. Mínimo 6 caracteres.");
            _senha = value;
        }
    }

    public IReadOnlyList<Perfil> ListaPerfis => _listaPerfis;

    public Usuario(string nome, string dataNasc, string email, string senha)
    {
        this.nome = nome;
        this.dataNasc = dataNasc;
        this.email = email;
        Senha = senha; // passa pela validacao
    }

    public void CriarPerfil(string nomePerfil)
    {
        Perfil novoPerfil = new Perfil(nomePerfil);
        _listaPerfis.Add(novoPerfil);
        Console.WriteLine($"Perfil '{nomePerfil}' criado com sucesso.");
    }

    public void ListarPerfis()
    {
        if (_listaPerfis.Count == 0)
        {
            Console.WriteLine("Nenhum perfil cadastrado.");
            return;
        }
        Console.WriteLine($"=== Perfis de {nome} ===");
        foreach (Perfil p in _listaPerfis)
            Console.WriteLine($"- {p.nome}");
    }

    public List<Perfil> GetListaPerfis()
    {
        return _listaPerfis;
    }
}