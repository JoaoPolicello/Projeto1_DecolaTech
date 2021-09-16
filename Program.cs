using System;

namespace CatalogoSpotifai
{
    class Program
    {
        static SpotifaiRepositorio repositorio = new SpotifaiRepositorio();
        static void Main(string[] args)
        {
			Console.WriteLine("Bem-vindo ao Spotifai!");
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						InserirMusica();
						break;
					case "2":
						AtualizarMusica();
						break;
					case "3":
						AvaliarMusica();
						break;
					case "4":
						ListarMusicas();
						break;
					case "5":
						VisualizarMusica();
						break;
					case "6":
						ExcluirMusica();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.WriteLine("Volte sempre!");
        }

		private static void InserirMusica()
		{
			Console.WriteLine("Inserir nova música");
			Console.WriteLine();

			Console.Write("Digite o título da música: ");
			string entradaTitulo = Console.ReadLine();
			Console.WriteLine();
			while( entradaTitulo.Length < 3 || entradaTitulo.Length > 50)
			{
				Console.WriteLine("O título de ter entre 3 e 50 caracteres.");
				Console.Write("Digite o título da música: ");
				entradaTitulo = Console.ReadLine();
			}
            
			Console.Write("Digite o artista da música: ");
			string entradaArtista = Console.ReadLine();
			Console.WriteLine();
			while( entradaArtista.Length < 3 || entradaArtista.Length > 50)
			{
				Console.WriteLine("O nome do artista de ter entre 3 e 50 caracteres.");
				Console.Write("Digite o artista da música: ");
				entradaArtista = Console.ReadLine();
			}
            
			Console.Write("Digite o álbum da música: ");
			string entradaAlbum = Console.ReadLine();
			Console.WriteLine();
			while( entradaAlbum.Length < 3 || entradaAlbum.Length > 50)
			{
				Console.WriteLine("O nome do álbum de ter entre 3 e 50 caracteres.");
				Console.Write("Digite o álbum da música: ");
				entradaAlbum = Console.ReadLine();
			}

			Console.Write("Digite o ano da música: ");
			int entradaAno = int.Parse(Console.ReadLine());
			Console.WriteLine();
			while( entradaAno < 0 || entradaAno > 2021)
			{
				Console.WriteLine("O ano deve ser entre 0 e 2021.");
				Console.Write("Digite o ano da música: ");
				entradaAno = int.Parse(Console.ReadLine());
				Console.WriteLine();
			}

            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
			Console.WriteLine();
			while( entradaGenero < 1 || entradaGenero > 13)
			{
				Console.WriteLine("Número inválido.");
				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
				Console.WriteLine();
				Console.Write("Digite o gênero entre as opções acima: ");
				entradaGenero = int.Parse(Console.ReadLine());
				Console.WriteLine();
			}

            Console.Write("Digite o número de avaliações da música: ");
			int entradaNmrAvaliacoes = int.Parse(Console.ReadLine());
			Console.WriteLine();
			while( entradaNmrAvaliacoes < 0)
			{
				Console.WriteLine("O número de avaliações deve ser maior que zero.");
				Console.Write("Digite o número de avaliações da música: ");
				entradaNmrAvaliacoes = int.Parse(Console.ReadLine());
				Console.WriteLine();
			}

            Console.Write("Digite a avaliação da música: ");
			double entradaAvaliacao = double.Parse(Console.ReadLine());
			Console.WriteLine();
			while( entradaAvaliacao < 0 || entradaAvaliacao > 10)
			{
				Console.WriteLine("A avaliação deve ser entre  0 e 10.");
				Console.Write("Digite a avaliação da música: ");
				entradaAvaliacao = double.Parse(Console.ReadLine());
				Console.WriteLine();
			}
            
			Console.Write("Digite a letra da música: ");
			string entradaLetra = Console.ReadLine();
			Console.WriteLine();
			while( entradaLetra.Length < 3 || entradaLetra.Length > 50)
			{
				Console.WriteLine("A letra da música deve ter entre 3 e 1000 caracteres.");
				Console.Write("Digite a letra da música: ");
				entradaLetra = Console.ReadLine();
			}

			Musica novaMusica = new Musica(id: repositorio.ProximoId(),
										titulo: entradaTitulo,
                                        artista: entradaArtista,
                                        album: entradaAlbum,
										ano: entradaAno,
										genero: (Genero)entradaGenero,
										nmrAvaliacoes: entradaNmrAvaliacoes,
                                        avaliacao: entradaAvaliacao,
                                        letra: entradaLetra);

			repositorio.Insere(novaMusica);
		}

		private static void AtualizarMusica()
		{
			if(repositorio.ProximoId() == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				return;
			}
			Console.Write("Digite o id da música: ");
			int entradaIndice = int.Parse(Console.ReadLine());
			Console.WriteLine();
			while( entradaIndice < 0 || entradaIndice + 1 > repositorio.ProximoId())
			{
				Console.WriteLine($"O valor do id deve ser de 0 até {repositorio.ProximoId() - 1}.");
				Console.Write("Digite o id da música: ");
				entradaIndice = int.Parse(Console.ReadLine());
				Console.WriteLine();
			}

			Console.Write("Digite o título da música: ");
			string entradaTitulo = Console.ReadLine();
			Console.WriteLine();
			while( entradaTitulo.Length < 3 || entradaTitulo.Length > 50)
			{
				Console.WriteLine("O título de ter entre 3 e 50 caracteres.");
				Console.Write("Digite o título da música: ");
				entradaTitulo = Console.ReadLine();
				Console.WriteLine();
			}
            
			Console.Write("Digite o artista da música: ");
			string entradaArtista = Console.ReadLine();
			Console.WriteLine();
			while( entradaArtista.Length < 3 || entradaArtista.Length > 50)
			{
				Console.WriteLine("O nome do artista de ter entre 3 e 50 caracteres.");
				Console.Write("Digite o artista da música: ");
				entradaArtista = Console.ReadLine();
				Console.WriteLine();
			}
            
			Console.Write("Digite o álbum da música: ");
			string entradaAlbum = Console.ReadLine();
			Console.WriteLine();
			while( entradaAlbum.Length < 3 || entradaAlbum.Length > 50)
			{
				Console.WriteLine("O nome do álbum de ter entre 3 e 50 caracteres.");
				Console.Write("Digite o álbum da música: ");
				entradaAlbum = Console.ReadLine();
				Console.WriteLine();
			}

			Console.Write("Digite o ano da música: ");
			int entradaAno = int.Parse(Console.ReadLine());
			Console.WriteLine();
			while( entradaAno < 0 || entradaAno > 2021)
			{
				Console.WriteLine("O ano deve ser entre 0 e 2021.");
				Console.Write("Digite o ano da música: ");
				entradaAno = int.Parse(Console.ReadLine());
				Console.WriteLine();
			}

            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
			Console.WriteLine();
			while( entradaGenero < 1 || entradaGenero > 13)
			{
				Console.WriteLine("Número inválido.");
				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
				Console.Write("Digite o gênero entre as opções acima: ");
				entradaGenero = int.Parse(Console.ReadLine());
				Console.WriteLine();
			}

            Console.Write("Digite o número de avaliações da música: ");
			int entradaNmrAvaliacoes = int.Parse(Console.ReadLine());
			Console.WriteLine();
			while( entradaNmrAvaliacoes < 0)
			{
				Console.WriteLine("O número de avaliações deve ser maior que zero.");
				Console.Write("Digite o número de avaliações da música: ");
				entradaNmrAvaliacoes = int.Parse(Console.ReadLine());
				Console.WriteLine();
			}

            Console.Write("Digite a avaliação da música: ");
			double entradaAvaliacao = double.Parse(Console.ReadLine());
			Console.WriteLine();
			while( entradaAvaliacao < 0 || entradaAvaliacao > 10)
			{
				Console.WriteLine("A avaliação deve ser entre  0 e 10.");
				Console.Write("Digite a avaliação da música: ");
				entradaAvaliacao = double.Parse(Console.ReadLine());
				Console.WriteLine();
			}
            
			Console.Write("Digite a letra da música: ");
			string entradaLetra = Console.ReadLine();
			Console.WriteLine();
			while( entradaLetra.Length < 3 || entradaLetra.Length > 1000)
			{
				Console.WriteLine("A letra da música deve ter entre 3 e 1000 caracteres.");
				Console.Write("Digite a letra da música: ");
				entradaLetra = Console.ReadLine();
			}

			Musica atualizaMusica = new Musica(id: entradaIndice,
										titulo: entradaTitulo,
                                        artista: entradaArtista,
                                        album: entradaAlbum,
										ano: entradaAno,
										genero: (Genero)entradaGenero,
										nmrAvaliacoes: entradaNmrAvaliacoes,
                                        avaliacao: entradaAvaliacao,
                                        letra: entradaLetra);

			repositorio.Atualiza(entradaIndice, atualizaMusica);
		}

		private static void AvaliarMusica()
		{
			if(repositorio.ProximoId() == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				return;
			}
			Console.Write("Digite o id da música: ");
			int indiceMusica = int.Parse(Console.ReadLine());
			Console.WriteLine();
			while( indiceMusica < 0 || indiceMusica + 1 > repositorio.ProximoId())
			{
				Console.WriteLine($"O valor do id deve ser entre 0 e {repositorio.ProximoId()-1}.");
				Console.Write("Digite o id da música: ");
				indiceMusica = int.Parse(Console.ReadLine());
				Console.WriteLine();
			}

			Console.Write("Digite sua avaliação da música: ");
			double avaliacaoMusica = double.Parse(Console.ReadLine());
			Console.WriteLine();
			while( avaliacaoMusica < 0 || avaliacaoMusica > 10)
			{
				Console.WriteLine("A avaliação deve ser entre  0 e 10.");
				Console.Write("Digite sua avaliação da música: ");
				avaliacaoMusica = double.Parse(Console.ReadLine());
				Console.WriteLine();
			}

			repositorio.Avalia(indiceMusica, avaliacaoMusica);
		}

        private static void ListarMusicas()
		{
			Console.WriteLine("Listar músicas");
			Console.WriteLine();

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				Console.WriteLine();
				return;
			}

			foreach (var musica in lista)
			{
                var excluido = musica.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", musica.retornaId(), musica.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
			Console.WriteLine();
		}

		private static void VisualizarMusica()
		{
			if(repositorio.ProximoId() == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				return;
			}
			Console.Write("Digite o id da música: ");
			int indiceMusica = int.Parse(Console.ReadLine());
			Console.WriteLine();
			while( indiceMusica < 0 || indiceMusica + 1 > repositorio.ProximoId())
			{
				Console.WriteLine($"O valor do id deve ser entre 0 e {repositorio.ProximoId()-1}.");
				Console.Write("Digite o id da música: ");
				indiceMusica = int.Parse(Console.ReadLine());
				Console.WriteLine();
			}

			var musica = repositorio.RetornaPorId(indiceMusica);

			Console.WriteLine(musica);
		}

        private static void ExcluirMusica()
		{
			if(repositorio.ProximoId() == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				return;
			}
			Console.Write("Digite o id da musica: ");
			int indiceMusica = int.Parse(Console.ReadLine());
			Console.WriteLine();
			while( indiceMusica < 0 || indiceMusica + 1 > repositorio.ProximoId())
			{
				Console.WriteLine($"O valor do id deve ser entre 0 e {repositorio.ProximoId()-1}.");
				Console.Write("Digite o id da música: ");
				indiceMusica = int.Parse(Console.ReadLine());
				Console.WriteLine();
			}

			repositorio.Exclui(indiceMusica);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine();
			Console.WriteLine("1- Inserir nova música");
			Console.WriteLine("2- Atualizar música");
			Console.WriteLine("3- Avaliar música");
			Console.WriteLine("4- Listar músicas");
			Console.WriteLine("5- Visualizar música");
			Console.WriteLine("6- Excluir música");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}