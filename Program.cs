using System;
using System.Collections.Generic;

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
        Catalogo meuCatalogo = new Catalogo();
        Usuario usuario1 = new Usuario("Ana", "01/01/2000", "ana@email.com", "senha123");
        usuario1.CriarPerfil("Ana");
        List<Perfil> perfis = usuario1.GetListaPerfis();
        Perfil meuPerfil = perfis[0];

        Temporada temporada1 = new Temporada();
        temporada1.CriarTemporada(1);
        Episodio ep1 = new Episodio();
        ep1.CriarEpisodio(1, 45, "Piloto", "João Silva");
        Episodio ep2 = new Episodio();
        ep2.CriarEpisodio(2, 50, "O Retorno", "Maria Santos");
        temporada1.AdicionarEp(ep1);
        temporada1.AdicionarEp(ep2);

        bool rodando = true;
        while (rodando)
        {
            Console.WriteLine("\n=== MENU STREAMING ===");
            Console.WriteLine("1. Listar Filmes");
            Console.WriteLine("2. Listar Séries");
            Console.WriteLine("3. Adicionar Filme");
            Console.WriteLine("4. Adicionar Série");
            Console.WriteLine("5. Executar Testes Automáticos");
            Console.WriteLine("6. Sair");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            try
            {
                switch (opcao)
                {
                    case "1":
                        meuCatalogo.ListarFilmes();
                        break;
                    case "2":
                        meuCatalogo.ListarSeries();
                        break;
                    case "3":
                        Console.Write("ID: "); int idF = int.Parse(Console.ReadLine());
                        Console.Write("Título: "); string tF = Console.ReadLine();
                        Console.Write("Ano: "); string anoF = Console.ReadLine();
                        Console.Write("Diretor: "); string dirF = Console.ReadLine();
                        Console.Write("Duração: "); int durF = int.Parse(Console.ReadLine());
                        Console.Write("Nota: "); int notaF = int.Parse(Console.ReadLine());
                        Console.Write("Classificação: "); int classF = int.Parse(Console.ReadLine());
                        Console.Write("Sinopse: "); string sinF = Console.ReadLine();
                        meuCatalogo.AdicionarFilme(idF, notaF, classF, anoF, tF, sinF, durF, dirF);
                        break;
                    case "4":
                        Console.Write("ID: "); int idS = int.Parse(Console.ReadLine());
                        Console.Write("Título: "); string tS = Console.ReadLine();
                        Console.Write("Ano: "); string anoS = Console.ReadLine();
                        Console.Write("Temporadas: "); int tempS = int.Parse(Console.ReadLine());
                        Console.Write("Duração Ep: "); int durS = int.Parse(Console.ReadLine());
                        Console.Write("Nota: "); int notaS = int.Parse(Console.ReadLine());
                        Console.Write("Classificação: "); int classS = int.Parse(Console.ReadLine());
                        Console.Write("Sinopse: "); string sinS = Console.ReadLine();
                        meuCatalogo.AdicionarSerie(idS, notaS, classS, anoS, tS, sinS, durS, tempS);
                        break;
                    case "5":
                        Console.WriteLine("\n=== EXECUTANDO TESTES ===");
                        temporada1.ListarEpisodios();
                        Series s1 = new Series { id = 1, titulo = "Dark", anoLancamento = "2017", numTemp = 1 };
                        s1.temporadas.Add(temporada1);
                        s1.ExibirDetalhes();

                        try { Usuario uInvalido = new Usuario("Teste", "01/01/2000", "t@em.com", "123"); }
                        catch (Exception e) { Console.WriteLine($"Erro esperado: {e.Message}"); }

                        Filmes f1 = new Filmes { id = 1, titulo = "Interestelar", anoLancamento = "2014", duracaoMinutos = 169, diretor = "C. Nolan" };
                        meuPerfil.AdicionarFavorito(f1);
                        meuPerfil.ListarFavoritos();
                        break;
                    case "6":
                        rodando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Entrada com formato incorreto. Digite números onde solicitado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no sistema: {ex.Message}");
            }
        }
    }
}