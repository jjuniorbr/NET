using System.Collections.Generic;
using LocalizaAmigos.Comum.Entidade;
using LocalizaAmigos.Negocio;

namespace LocalizaAmigos.Facade
{
    public class AmigoFacade
    {
        public AmigoFacade() { }

        public List<AmigoEntidade> ObterAmigosDisponiveisParaVisita()
        {
            return new AmigoNegocio().ObterAmigosDisponiveisParaVisita();
        }

        public AmigoEntidade PesquisarAmigoPorNome(string nome)
        {
            return new AmigoNegocio().PesquisarAmigoPorNome(nome);
        }

        public List<AmigoEntidade> ObterAmigosEmLocalizaoProxima(AmigoEntidade amigoVisitante)
        {
            return new AmigoNegocio().ObterAmigosEmLocalizaoProxima(amigoVisitante);
        }            
    }
}