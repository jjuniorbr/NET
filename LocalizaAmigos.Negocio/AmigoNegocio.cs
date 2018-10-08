using System.Collections.Generic;
using LocalizaAmigos.Comum.Entidade;
using LocalizaAmigos.Persistencia;

namespace LocalizaAmigos.Negocio
{
    public class AmigoNegocio
    {
        public AmigoNegocio() { }

        public List<AmigoEntidade> ObterAmigosDisponiveisParaVisita()
        {
            return new AmigoPersistencia().ObterAmigosDisponiveisParaVisita();
        }

        public AmigoEntidade PesquisarAmigoPorNome(string nome)
        {
            return new AmigoPersistencia().PesquisarAmigoPorNome(nome);
        }

        public List<AmigoEntidade> ObterAmigosEmLocalizaoProxima(AmigoEntidade amigoVisitante)
        {
            return new AmigoPersistencia().ObterAmigosEmLocalizaoProxima(amigoVisitante);
        }
    }
}
