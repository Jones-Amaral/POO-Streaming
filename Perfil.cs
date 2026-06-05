public class Perfil
{
    public string nome;
    public string avatar;
    private List<Conteudo> listaFavoritos = new List<Conteudo>();    // Agregação
    private List<Conteudo> listaAssistidos = new List<Conteudo>();   // Agregação
    private List<Conteudo> listaQueroAssistir = new List<Conteudo>(); // Agregação

    public Perfil(string nome, string avatar = "default")
    {
        this.nome = nome;
        this.avatar = avatar;
    }

    // ── FAVORITOS ────────────────────────────────────────────────
    public void AdicionarFavorito(Conteudo conteudo)
    {
        foreach (Conteudo c in listaFavoritos)
        {
            if (c.id == conteudo.id)
            {
                Console.WriteLine($"'{conteudo.titulo}' já está nos favoritos.");
                return;
            }
        }
        listaFavoritos.Add(conteudo);
        Console.WriteLine($"'{conteudo.titulo}' adicionado aos favoritos.");
    }

    public void RemoverFavorito(int id)
    {
        Conteudo encontrado = null;
        foreach (Conteudo c in listaFavoritos)
        {
            if (c.id == id) { encontrado = c; break; }
        }
        if (encontrado != null)
        {
            listaFavoritos.Remove(encontrado);
            Console.WriteLine($"'{encontrado.titulo}' removido dos favoritos.");
        }
        else
        {
            Console.WriteLine("Conteudo não encontrado nos favoritos.");
        }
    }

    public void ListarFavoritos()
    {
        Console.WriteLine($"\n=== Favoritos de {nome} ===");
        if (listaFavoritos.Count == 0) { Console.WriteLine("Nenhum favorito."); return; }
        foreach (Conteudo c in listaFavoritos)
            c.ExibirDetalhes();
    }

    // ── ASSISTIDOS ───────────────────────────────────────────────
    public void AdicionarAssistido(Conteudo conteudo)
    {
        foreach (Conteudo c in listaAssistidos)
        {
            if (c.id == conteudo.id)
            {
                Console.WriteLine($"'{conteudo.titulo}' já está nos assistidos.");
                return;
            }
        }
        listaAssistidos.Add(conteudo);
        Console.WriteLine($"'{conteudo.titulo}' marcado como assistido.");
    }

    public void RemoverAssistido(int id)
    {
        Conteudo encontrado = null;
        foreach (Conteudo c in listaAssistidos)
        {
            if (c.id == id) { encontrado = c; break; }
        }
        if (encontrado != null)
        {
            listaAssistidos.Remove(encontrado);
            Console.WriteLine($"'{encontrado.titulo}' removido dos assistidos.");
        }
        else
        {
            Console.WriteLine("Conteudo não encontrado nos assistidos.");
        }
    }

    public void ListarAssistidos()
    {
        Console.WriteLine($"\n=== Assistidos de {nome} ===");
        if (listaAssistidos.Count == 0) { Console.WriteLine("Nenhum assistido."); return; }
        foreach (Conteudo c in listaAssistidos)
            c.ExibirDetalhes();
    }

    // ── QUERO ASSISTIR ───────────────────────────────────────────
    public void AdicionarQueroAssistir(Conteudo conteudo)
    {
        foreach (Conteudo c in listaQueroAssistir)
        {
            if (c.id == conteudo.id)
            {
                Console.WriteLine($"'{conteudo.titulo}' já está na lista Quero Assistir.");
                return;
            }
        }
        listaQueroAssistir.Add(conteudo);
        Console.WriteLine($"'{conteudo.titulo}' adicionado à lista Quero Assistir.");
    }

    public void RemoverQueroAssistir(int id)
    {
        Conteudo encontrado = null;
        foreach (Conteudo c in listaQueroAssistir)
        {
            if (c.id == id) { encontrado = c; break; }
        }
        if (encontrado != null)
        {
            listaQueroAssistir.Remove(encontrado);
            Console.WriteLine($"'{encontrado.titulo}' removido da lista Quero Assistir.");
        }
        else
        {
            Console.WriteLine("Conteudo não encontrado na lista Quero Assistir.");
        }
    }

    public void ListarQueroAssistir()
    {
        Console.WriteLine($"\n=== Quero Assistir de {nome} ===");
        if (listaQueroAssistir.Count == 0) { Console.WriteLine("Lista vazia."); return; }
        foreach (Conteudo c in listaQueroAssistir)
            c.ExibirDetalhes();
    }

    // ── EXIBIR TODAS AS LISTAS ───────────────────────────────────
    public void ExibirTodasAsListas()
    {
        ListarFavoritos();
        ListarAssistidos();
        ListarQueroAssistir();
    }
}