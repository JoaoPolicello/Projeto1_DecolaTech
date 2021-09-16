using System;

namespace CatalogoSpotifai
{
    public class Musica : EntidadeBase
    {
        protected internal string Titulo { get; set; }
        protected internal string Artista { get; set; }
        protected internal string Album { get; set; }
        protected internal int Ano { get; set; }
        protected internal Genero Genero { get; set; }
        protected internal int NmrAvaliacoes { get; set; }
        protected internal double Avaliacao { get; set; }
        protected internal string Letra { get; set; }
        protected internal bool Excluido { get; set; }

        public Musica(int id, string titulo, string artista, string album, int ano, Genero genero, int nmrAvaliacoes, double avaliacao, string letra)
		{
			this.Id = id;
			this.Titulo = titulo;
			this.Artista = artista;
			this.Album = album;
			this.Ano = ano;
			this.Genero = genero;
            this.NmrAvaliacoes = nmrAvaliacoes;
            this.Avaliacao = avaliacao;
			this.Letra = letra;
            this.Excluido = false;
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Artista: " + this.Artista + Environment.NewLine;
            retorno += "Album: " + this.Album + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Avaliação: " + this.Avaliacao + Environment.NewLine;
            retorno += "Letra: " + this.Letra + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}
        
        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}

        public bool retornaExcluido()
		{
			return this.Excluido;
		}

        public void Excluir()
        {
            this.Excluido = true;
        }
        
        public void Avaliar(double avaliacao)
        {
            this.Avaliacao = Math.Round((( this.Avaliacao * this.NmrAvaliacoes + avaliacao) / ( this.NmrAvaliacoes + 1)), 1);
			this.NmrAvaliacoes++;
        }
    }
}