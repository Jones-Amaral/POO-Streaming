abstract class Conteudo
{
    public int notaConteudo;
    public int id;
    public int classificacaoInd;
    public string anoLancamento;
    public string titulo;
    public string sinopse;
    public virtual void Reproduzir();
    public virtual void ExibirDetalhes();
}

class Filmes : Conteudo
{
    public int duracaoMinutor;
    public string diretor;
    public override void Reproduzir();
    public override void ExibirDetalhes();
}

class Series : Conteudo
{
    public int duracaoEp;
    public int numTemp;
    public List<Temporada> temporadas;
    public override void Reproduzir();
    public override void ExibirDetalhes();
}

class Temporada
{
    public List<Episodios> listaEps; // Composição
    public int numTem;
    public void CriarTemporada(int numTemp);
}

class Episodio
{
    public int numEp;
    public string tituloEp;
    public int duracaoEp;
    public string diretorEp;
    public void CriarEp(int numEp, int duracaoEp, string tituloEp, string diretorEp);
}

class Usuario
{
    protected string nome;
    protected string dataNasc;
    protected string email;
    protected string senha;
    public void CriarPerfil(string nomePerfil);
    public List<Perfil> listaPerfis; // Composição
}

class Perfil
{
    public string nome;
    public string avatar;
    public Lista<Conteudo> listaFavoritos;// Agregação
    public void AdicionarFavorito(Conteudo x) { }
}

class Catalogo
{
    public List<Series> listaSeries; // Composição
    public Lista<Filmes> listaFilmes; // Composição
    public void ListarFilmes();
    public void ListarSeries();
    public void AdicionarFilme(int id, int nota, int classif, int ano, string titulo, string sinopse, int duração, string diretor);
    public void AdicionarSerie(int id, int nota, int classif, int ano, string titulo, string sinopse, int duracaoEp, int numTemp);
}

class Categoria
{
    public string nomeCategoria;
    public Lista<Conteudo> conteudos; // Agregação
    public void AdicionarCategoria(string nomeCategoria);
    public void ListarCategoria();
}

class Program
{
    static void Main()
    {

    }
}