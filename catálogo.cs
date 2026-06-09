using System;
using System.Collections.Generic;

namespace CatalogoMidias
{
    
    // CLASSE ABSTRATA CONTEUDO
   
    public abstract class Conteudo
    {
        protected int id;
        protected int notaConteudo;
        protected int classificacaoInd;
        protected int anoLanc;         
        protected string titulo;
        protected string sinopse;

        
        public int Id { get => id; set => id = value; }
        public int NotaConteudo { get => notaConteudo; set => notaConteudo = value; }
        public int ClassificacaoInd { get => classificacaoInd; set => classificacaoInd = value; }
        public int AnoLanc { get => anoLanc; set => anoLanc = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Sinopse { get => sinopse; set => sinopse = value; }

        
        public Conteudo(int id, int notaConteudo, int classificacaoInd, int anoLanc, string titulo, string sinopse)
        {
            Id = id;
            NotaConteudo = notaConteudo;
            ClassificacaoInd = classificacaoInd;
            AnoLanc = anoLanc;
            Titulo = titulo;
            Sinopse = sinopse;
        }

        
        public virtual void Reproduzir()
        {
            Console.WriteLine($"▶ Iniciando a reprodução de: {Titulo}");
        }

        public virtual void ExibirDetalhes()
        {
            Console.WriteLine($"\n--- {Titulo} ({AnoLanc}) ---");
            Console.WriteLine($"ID: {Id} | Nota: {NotaConteudo}/10 | Classificação: {ClassificacaoInd}+");
            Console.WriteLine($"Sinopse: {Sinopse}");
        }
    }

    
    // CLASSE FILMES
    
    public class Filmes : Conteudo
    {
        
        public int DuracaoMinutos { get; set; }
        public string Diretor { get; set; }

        
        public Filmes(int id, int notaConteudo, int classificacaoInd, int anoLanc, string titulo, string sinopse, int duracaoMinutos, string diretor)
            : base(id, notaConteudo, classificacaoInd, anoLanc, titulo, sinopse)
        {
            DuracaoMinutos = duracaoMinutos;
            Diretor = diretor;
        }

        public override void Reproduzir()
        {
            Console.WriteLine($"▶ Reproduzindo o filme '{Titulo}' - Duração: {DuracaoMinutos} min.");
        }

        public override void ExibirDetalhes()
        {
            base.ExibirDetalhes(); 
            Console.WriteLine($"Diretor: {Diretor} | Duração: {DuracaoMinutos} minutos");
        }
    }

    
    // CLASSE SERIES
    
    public class Series : Conteudo
    {
       
        public int DuracaoEp { get; set; }
        public int NumTemp { get; set; }
        
        
        public List<Temporada> Temporadas { get; set; }

        public Series(int id, int notaConteudo, int classificacaoInd, int anoLanc, string titulo, string sinopse, int duracaoEp, int numTemp)
            : base(id, notaConteudo, classificacaoInd, anoLanc, titulo, sinopse)
        {
            DuracaoEp = duracaoEp;
            NumTemp = numTemp;
            Temporadas = new List<Temporada>();
        }

        public override void Reproduzir()
        {
            Console.WriteLine($"▶ Abrindo os episódios da série '{Titulo}'...");
        }

        public override void ExibirDetalhes()
        {
            base.ExibirDetalhes(); 
            Console.WriteLine($"Temporadas: {NumTemp} | Duração média por Ep: {DuracaoEp} min.");
        }
    }

    
    // CLASSE CATALOGO
    
    public class Catalogo
    {
       
        public List<Series> ListaSeries { get; set; }
        public List<Filmes> ListaFilmes { get; set; }

        public Catalogo()
        {
            ListaSeries = new List<Series>();
            ListaFilmes = new List<Filmes>();
        }

        public void AdicionarFilme(Filmes filme)
        {
            ListaFilmes.Add(filme);
            Console.WriteLine($"\nFilme '{filme.Titulo}' adicionado ao catálogo.");
        }

        public void AdicionarSerie(Series serie)
        {
            ListaSeries.Add(serie);
            Console.WriteLine($"\nSérie '{serie.Titulo}' adicionada ao catálogo.");
        }

        public void ListarFilmes()
        {
            Console.WriteLine("\n========== CATÁLOGO DE FILMES ==========");
            if (ListaFilmes.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }

            foreach (Filmes filme in ListaFilmes)
            {
                filme.ExibirDetalhes();
            }
        }

        public void ListarSeries()
        {
            Console.WriteLine("\n========== CATÁLOGO DE SÉRIES ==========");
            if (ListaSeries.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (Series serie in ListaSeries)
            {
                serie.ExibirDetalhes();
            }
        }
    }
}