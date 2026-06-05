class Usuario
{
    protected string nome;
    protected string dataNasc;
    protected string email;
    protected string senha;
    private List<Perfil> listaPerfis = new List<Perfil>();

    public Usuario(string nome, string dataNasc, string email, string senha)
    {
        this.nome = nome;
        this.dataNasc = dataNasc;
        this.email = email;
        this.senha = senha;
    }

    public void CriarPerfil(string nomePerfil)
    {
        Perfil novoPerfil = new Perfil(nomePerfil);
        listaPerfis.Add(novoPerfil);
        Console.WriteLine($"Perfil '{nomePerfil}' criado com sucesso.");
    }

    public void ListarPerfis()
    {
        if (listaPerfis.Count == 0)
        {
            Console.WriteLine("Nenhum perfil cadastrado.");
            return;
        }
        Console.WriteLine($"=== Perfis de {nome} ===");
        foreach (Perfil p in listaPerfis)
        {
            Console.WriteLine($"- {p.nome}");
        }
    }

    public List<Perfil> GetListaPerfis()
    {
        return listaPerfis;
    }
}