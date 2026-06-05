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

        // Criando usuario
        Console.WriteLine("\n=== TESTE USUARIO E PERFIL ===");
        Usuario usuario1 = new Usuario("Ana", "01/01/2000", "ana@email.com", "senha123");

        // Criando perfis
        usuario1.CriarPerfil("Ana");
        usuario1.CriarPerfil("Familia");
        usuario1.ListarPerfis();

        // Pegando o primeiro perfil e testando favoritos
        List<Perfil> perfis = usuario1.GetListaPerfis();
        Perfil meuPerfil = perfis[0];

        // Criando um filme para adicionar nos favoritos
        Filmes filme1 = new Filmes();
        filme1.id = 1;
        filme1.titulo = "Interestelar";
        filme1.anoLancamento = "2014";
        filme1.duracaoMinutos = 169;
        filme1.diretor = "Christopher Nolan";

        // Testando favoritos
        meuPerfil.AdicionarFavorito(filme1);
        meuPerfil.AdicionarFavorito(filme1); // testa duplicata
        meuPerfil.ListarFavoritos();

        Console.WriteLine("\n=== TESTE LISTAS DO PERFIL ===");

        Filmes filme2 = new Filmes();
        filme2.id = 2;
        filme2.titulo = "Inception";
        filme2.anoLancamento = "2010";
        filme2.duracaoMinutos = 148;
        filme2.diretor = "Christopher Nolan";

        meuPerfil.AdicionarAssistido(filme1);
        meuPerfil.AdicionarQueroAssistir(filme2);
        meuPerfil.ExibirTodasAsListas();
    }
}