using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LocalizaAmigos.Comum.Entidade;

namespace LocalizaAmigos.Persistencia
{
    public class AmigoPersistencia
    {
        private List<AmigoEntidade> listaAmigos;

        public AmigoPersistencia() {

            listaAmigos = new List<AmigoEntidade>
            {
                new AmigoEntidade { Codigo = 0, Nome = "João Pedro", PosicaoGeografica = new LocalizacaoGeograficaEntidade { Latitude = -23, Longitude = -46 } },
                new AmigoEntidade { Codigo = 1, Nome = "Henrique", PosicaoGeografica = new LocalizacaoGeograficaEntidade { Latitude = -22, Longitude = -43 } },
                new AmigoEntidade { Codigo = 2, Nome = "Marcia", PosicaoGeografica = new LocalizacaoGeograficaEntidade { Latitude = -43, Longitude = -51 } },
                new AmigoEntidade { Codigo = 3, Nome = "Paulo", PosicaoGeografica = new LocalizacaoGeograficaEntidade { Latitude = 15, Longitude = 50 } },
                new AmigoEntidade { Codigo = 4, Nome = "Regiane", PosicaoGeografica = new LocalizacaoGeograficaEntidade { Latitude = 38, Longitude = 40 } },
                new AmigoEntidade { Codigo = 5, Nome = "Maria", PosicaoGeografica = new LocalizacaoGeograficaEntidade { Latitude = -31, Longitude = -19 } },
            };

        }

        public List<AmigoEntidade> ObterAmigosDisponiveisParaVisita()
        {
            return listaAmigos;
        }

        public AmigoEntidade PesquisarAmigoPorNome(string nome)
        {
            AmigoEntidade objRetorno = listaAmigos
                .FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());

            return objRetorno;
        }

        public List<AmigoEntidade> ObterAmigosEmLocalizaoProxima(AmigoEntidade amigoVisitante)
        {
            List<AmigoEntidade> _ListaAmigosEmLocalizaoProximas = new List<AmigoEntidade>();

            LocalizacaoGeograficaEntidade localizaoAtual = amigoVisitante.PosicaoGeografica;

            var distanciaEntreAmigos = CalcularDistanciaEntreAmigos(amigoVisitante)
                                               .OrderBy(_ => _.Value)
                                               .Take(3);
                                    
            return distanciaEntreAmigos.Select(item => listaAmigos.ElementAt(item.Key)).ToList();
        }
        
        private Dictionary<int, double> CalcularDistanciaEntreAmigos(AmigoEntidade amigoVisitante)
        {
            var distanciaEntreAmigos = new Dictionary<int, double>();

            foreach (var amigo in listaAmigos)
            {
                if (amigo.Equals(amigoVisitante))
                    continue;

                var posicaoGeograficaAmigo = amigo.PosicaoGeografica;

                var teoremaPytagorasX = Math.Pow((amigoVisitante.PosicaoGeografica.Latitude - posicaoGeograficaAmigo.Latitude), 2);
                var teoremaPytagorasY = Math.Pow((amigoVisitante.PosicaoGeografica.Longitude - posicaoGeograficaAmigo.Longitude), 2);
                var teoremaPytagorasResultado = Math.Sqrt(teoremaPytagorasX + teoremaPytagorasY);

                distanciaEntreAmigos.Add(amigo.Codigo, teoremaPytagorasResultado);
            }
            return distanciaEntreAmigos;
        }
    }
}