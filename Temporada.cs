using System.Collections.Generic;

public class Temporada
{
    public List<Episodio> listaEpisodio;
    public int numTemporada;

    public Temporada()
    {
        listaEpisodio = new List<Episodio>();
    }

    public void CriarTemporada(int numTemporada)
    {
        this.numTemporada = numTemporada;
    }

    public void AdicionarEp(Episodio ep)
    {
        listaEpisodio.Add(ep);
        Console.WriteLine("Episódio adicionado com sucesso.");
    }

    public void ListarEpisodios()
    {
        Console.WriteLine($"Temporada {numTemporada}");

        if (listaEpisodio.Count == 0)
        {
            Console.WriteLine("Nenhum episódio cadastrado.");
            return;
        }

        foreach (Episodio ep in listaEpisodio)
        {
            ep.ExibirEpisodio();
        }
    }
}