using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogoSpotifai.Interfaces;

namespace CatalogoSpotifai
{
    public class SpotifaiRepositorio : IRepositorio<Musica>
    {
        private static List<Musica> listaMusica = new List<Musica>();
		
		public void Atualiza(int id, Musica objeto)
		{
			listaMusica[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaMusica[id].Excluir();
		}

		public void Insere(Musica objeto)
		{
			listaMusica.Add(objeto);
		}

		public List<Musica> Lista()
		{
			return listaMusica;
		}

		public int ProximoId()
		{
			return listaMusica.Count;
		}

		public Musica RetornaPorId(int id)
		{
			return listaMusica[id];
		}

		public void Avalia(int id, double avaliacao)
		{
			listaMusica[id].Avaliar(avaliacao);
		}
    }
}