using System;
using System.Collections.Generic;

public class Categoria
{
    public string nomeCategoria;
    public List<Conteudo> conteudos;

    public Categoria()
    {
        conteudos = new List<Conteudo>();
    }

    public void AdicionarCategoria(string nomeCategoria)
    {
        this.nomeCategoria = nomeCategoria;
    }

    public void AdicionarConteudo(Conteudo conteudo)
    {
        conteudos.Add(conteudo);
    }

    public void ListarCategoria()
    {
        Console.WriteLine($"Categoria: {nomeCategoria}");

        if (conteudos.Count == 0)
        {
            Console.WriteLine("Nenhum conteúdo cadastrado.");
            return;
        }

        foreach (Conteudo conteudo in conteudos)
        {
            Console.WriteLine($"- {conteudo.titulo}");
        }
    }
}