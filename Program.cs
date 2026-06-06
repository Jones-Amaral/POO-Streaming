public abstract class Conteudo
{
    public int notaConteudo;
    public int id;
    public int classificacaoInd;
    public string anoLancamento;
    public string titulo;
    public string sinopse;
    public abstract void Reproduzir();
    public abstract void ExibirDetalhes();
}

public class Filmes : Conteudo
{
    public int duracaoMinutos;
    public string diretor;
    public override void Reproduzir()
    {
        Console.WriteLine($"Reproduzindo filme: {titulo}");
    }
    public override void ExibirDetalhes()
    {
        Console.WriteLine($"{titulo} ({anoLancamento}) - {duracaoMinutos} min - Diretor: {diretor}");
    }
}

public class Series : Conteudo
{
    public int duracaoEp;
    public int numTemp;
    public List<Temporada> temporadas = new List<Temporada>();
    public override void Reproduzir()
    {
        Console.WriteLine($"Reproduzindo série: {titulo}");
    }
    public override void ExibirDetalhes()
    {
        Console.WriteLine($"{titulo} ({anoLancamento}) - {numTemp} temporada(s)");
    }
}

public class Catalogo
{
    public List<Series> listaSeries = new List<Series>();
    public List<Filmes> listaFilmes = new List<Filmes>();
    public void ListarFilmes()
    {
        foreach (Filmes f in listaFilmes)
            f.ExibirDetalhes();
    }
    public void ListarSeries()
    {
        foreach (Series s in listaSeries)
            s.ExibirDetalhes();
    }
    public void AdicionarFilme(int id, int nota, int classif, string ano, string titulo, string sinopse, int duracao, string diretor)
    {
        Filmes f = new Filmes();
        f.id = id; f.notaConteudo = nota; f.classificacaoInd = classif;
        f.anoLancamento = ano; f.titulo = titulo; f.sinopse = sinopse;
        f.duracaoMinutos = duracao; f.diretor = diretor;
        listaFilmes.Add(f);
        Console.WriteLine($"Filme '{titulo}' adicionado ao catálogo.");
    }
    public void AdicionarSerie(int id, int nota, int classif, string ano, string titulo, string sinopse, int duracaoEp, int numTemp)
    {
        Series s = new Series();
        s.id = id; s.notaConteudo = nota; s.classificacaoInd = classif;
        s.anoLancamento = ano; s.titulo = titulo; s.sinopse = sinopse;
        s.duracaoEp = duracaoEp; s.numTemp = numTemp;
        listaSeries.Add(s);
        Console.WriteLine($"Série '{titulo}' adicionada ao catálogo.");
    }
}

class Program
{
    static void Main()
    {
        // Criando temporada
        Temporada temporada1 = new Temporada();
        temporada1.CriarTemporada(1);

        // Criando episódios
        Episodio ep1 = new Episodio();
        ep1.CriarEpisodio(1, 45, "Piloto", "João Silva");

        Episodio ep2 = new Episodio();
        ep2.CriarEpisodio(2, 50, "O Retorno", "Maria Santos");

        // Adicionando episódios na temporada
        temporada1.AdicionarEp(ep1);
        temporada1.AdicionarEp(ep2);

        // Listando episódios
        Console.WriteLine("=== TESTE TEMPORADA ===");
        temporada1.ListarEpisodios();

        Console.WriteLine();

        Console.WriteLine("=== TESTE SÉRIE ===");

        Series serie1 = new Series();
        serie1.id = 1;
        serie1.titulo = "Dark";
        serie1.anoLancamento = "2017";
        serie1.numTemp = 1;

        serie1.temporadas.Add(temporada1);
        serie1.ExibirDetalhes();

        Console.WriteLine();

        Console.WriteLine("\n=== TESTE CATEGORIA ===");

        Filmes filmeCategoria1 = new Filmes();
        filmeCategoria1.titulo = "Interestelar";

        Filmes filmeCategoria2 = new Filmes();
        filmeCategoria2.titulo = "Inception";

        Categoria ficcao = new Categoria();
        ficcao.AdicionarCategoria("Ficção Científica");

        ficcao.AdicionarConteudo(filmeCategoria1);
        ficcao.AdicionarConteudo(filmeCategoria2);

        ficcao.ListarCategoria();

        Console.WriteLine("\n=== TESTE USUARIO E PERFIL ===");

        // Teste de senha curta (deve lancar excecao)
        try
        {
            Usuario usuarioInvalido = new Usuario("Teste", "01/01/2000", "teste@email.com", "123");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro esperado: {e.Message}");
        }

        // Criando usuario valido
        Usuario usuario1 = new Usuario("Ana", "01/01/2000", "ana@email.com", "senha123");
        Console.WriteLine($"Usuario criado: {usuario1.nome}");

        // Criando perfis
        usuario1.CriarPerfil("Ana");
        usuario1.CriarPerfil("Familia");
        usuario1.ListarPerfis();

        // Pegando o primeiro perfil
        List<Perfil> perfis = usuario1.GetListaPerfis();
        Perfil meuPerfil = perfis[0];

        // Criando conteudos para testar
        Filmes filme1 = new Filmes();
        filme1.id = 1; filme1.titulo = "Interestelar";
        filme1.anoLancamento = "2014"; filme1.duracaoMinutos = 169;
        filme1.diretor = "Christopher Nolan";

        Filmes filme2 = new Filmes();
        filme2.id = 2; filme2.titulo = "Inception";
        filme2.anoLancamento = "2010"; filme2.duracaoMinutos = 148;
        filme2.diretor = "Christopher Nolan";

        // Testando favoritos
        Console.WriteLine("\n-- Favoritos --");
        meuPerfil.AdicionarFavorito(filme1);
        meuPerfil.AdicionarFavorito(filme1); // testa duplicata
        meuPerfil.ListarFavoritos();

        // Testando assistidos
        Console.WriteLine("\n-- Assistidos --");
        meuPerfil.AdicionarAssistido(filme1);
        meuPerfil.AdicionarAssistido(filme1); // testa duplicata
        meuPerfil.ListarAssistidos();

        // Testando quero assistir
        Console.WriteLine("\n-- Quero Assistir --");
        meuPerfil.AdicionarQueroAssistir(filme2);
        meuPerfil.ListarQueroAssistir();

        // Exibindo todas as listas
        Console.WriteLine("\n-- Todas as listas --");
        meuPerfil.ExibirTodasAsListas(); meuPerfil.ExibirTodasAsListas();
    }
}