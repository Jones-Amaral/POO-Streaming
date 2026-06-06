public class Episodio
{
    public int numEp;
    public string tituloEp;
    public int duracaoEp;
    public string diretorEp;

    public void CriarEpisodio(int numEp, int duracaoEp, string tituloEp, string diretorEp)
    {
        this.numEp = numEp;
        this.duracaoEp = duracaoEp;
        this.tituloEp = tituloEp;
        this.diretorEp = diretorEp;
    }

    public void ExibirEpisodio()
    {
        Console.WriteLine($"Episódio {numEp}");
        Console.WriteLine($"Título: {tituloEp}");
        Console.WriteLine($"Duração: {duracaoEp} min");
        Console.WriteLine($"Diretor: {diretorEp}");
        Console.WriteLine("-----------------------");
    }
}