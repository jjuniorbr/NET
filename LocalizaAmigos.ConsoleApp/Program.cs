using System;
using System.Collections.Generic;
using System.Threading;
using LocalizaAmigos.Comum.Entidade;
using LocalizaAmigos.Facade;

namespace LocalizaAmigos.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Iniciando Aplicativo de Localização de Amigos \n");

            ApresentarAmigosDisponiveisParaVisita();           
            SelecionarAmigoParaVisitar();
                       
            Console.ReadKey();
            Console.WriteLine(" --> Pressione qualquer tecla para finalizar o programa ....");           
        }


        private static void ApresentarAmigosDisponiveisParaVisita()
        {
            List<AmigoEntidade> _ListaAmigosParaVisita = new AmigoFacade().ObterAmigosDisponiveisParaVisita();

            Console.WriteLine("   ***** Relatório de Amigos disponíveis para visita. *****\n");

            foreach (AmigoEntidade amigoEntidade in _ListaAmigosParaVisita)
            {
                Console.WriteLine(String.Format("Nome: {0} - Localização Geográfica --> Latitude: {1} : Longitude: {2}",
                                                 amigoEntidade.Nome, amigoEntidade.PosicaoGeografica.Latitude, amigoEntidade.PosicaoGeografica.Longitude));
            }
            Console.WriteLine("");
        }

        private static void SelecionarAmigoParaVisitar()
        {
            Console.WriteLine("Digite o nome do Amigo que você pretende Visitar!");
            string nomeAmigoVisita = Console.ReadLine();
            Console.WriteLine(" ");

            AmigoEntidade amigoVisita = new AmigoFacade().PesquisarAmigoPorNome(nomeAmigoVisita);

            if (amigoVisita == null)
                Console.WriteLine("O Amigo informado não existe.");
            else
            {
                List<AmigoEntidade> listaAmigos = new AmigoFacade().ObterAmigosEmLocalizaoProxima(amigoVisita);

                if (listaAmigos.Count > 0)
                {
                    Console.WriteLine("   ***** Amigos próximos: *****");
                    Console.WriteLine(" ");

                    foreach (AmigoEntidade amigo in listaAmigos)
                    {
                        Console.WriteLine(string.Concat("Nome: ", amigo.Nome));
                    }
                }
                else
                    Console.WriteLine("Nenhum amigo encontrado.!");
            }          

        }

    }
}