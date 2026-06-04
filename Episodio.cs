public class Episodio
{
    public int numEpisodio;
    public string tituloEpisodio;
    public int duracaoEpisodio;
    public string diretorEpisodio;

    public void CriarEpisodio(int numEpisodio, int duracaoEpisodio, string tituloEpisodio, string diretorEpisodio)
    {
        this.numEpisodio = numEpisodio;
        this.duracaoEpisodio = duracaoEpisodio;
        this.tituloEpisodio = tituloEpisodio;
        this.diretorEpisodio = diretorEpisodio;
    }

    public void ExibirEpisodio()
    {
        Console.WriteLine($"Episódio {numEpisodio}");
        Console.WriteLine($"Título: {tituloEpisodio}");
        Console.WriteLine($"Duração: {duracaoEpisodio} min");
        Console.WriteLine($"Diretor: {diretorEpisodio}");
        Console.WriteLine("-----------------------");
    }
}