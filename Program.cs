using System;

namespace DIO.Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
          
          string opcaoUsuario = ObterOpcaoUsuario();
          while (opcaoUsuario.ToUpper() != "X")
          {
              switch (opcaoUsuario)
              {
                  case "1":
                  ListaSeries();
                  break;

                  case "2":
                  InserirSerie();
                  break;

                  case "3":
                  //AtualizarSerie();
                  break;

                  case "4":
                  //ExcluirSerie();
                  break;

                  case "5":
                  //VisualizarSerie();
                  break;

                  case "C":
                  Console.Clear();
                  break;

                  default:
                   throw new ArgumentOutOfRangeException();
              }
              opcaoUsuario = ObterOpcaoUsuario();
          }
           Console.WriteLine("Obrigado por usar os nosso serviços.");
           Console.ReadLine();

        }


        //Listando as Séries
        private static void ListaSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }

        }
        
        //Inserir Série
        private static void InserirSerie()
        {  
            Console.WriteLine("Inserir nova Série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genêro entre as opções");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Serie");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série");
            string EntradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: EntradaDescricao);

            repositorio.Insere(novaSerie);


        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar a Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
