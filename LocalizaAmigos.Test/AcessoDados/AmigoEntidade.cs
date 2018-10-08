using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaAmigos.Test.AcessoDados
{
    public class AmigoEntidade
    {
        public List<AmigoEntidade> listaAmigos;

        public AmigoEntidade()
        {
            listaAmigos = new List<AmigoEntidade>
            {
                new AmigoEntidade { Codigo = 0, Nome = "João Pedro", PosicaoGeografica = new LocalizacaoGeograficaEntidade { Latitude = -23, Longitude = -46 } },
                new AmigoEntidade { Codigo = 1, Nome = "Henrique", PosicaoGeografica = new LocalizacaoGeograficaEntidade { Latitude = -22, Longitude = -43 } },
                new AmigoEntidade { Codigo = 2, Nome = "Marcia", PosicaoGeografica = new LocalizacaoGeograficaEntidade { Latitude = -43, Longitude = -51 } },
                new AmigoEntidade { Codigo = 3, Nome = "Paulo", PosicaoGeografica = new LocalizacaoGeograficaEntidade { Latitude = 15, Longitude = 50 } },
                new AmigoEntidade { Codigo = 4, Nome = "Regiane", PosicaoGeografica = new LocalizacaoGeograficaEntidade { Latitude = 38, Longitude = 40 } },
                new AmigoEntidade { Codigo = 5, Nome = "Maria", PosicaoGeografica = new LocalizacaoGeograficaEntidade { Latitude = -31, Longitude = -19 } }
            };
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public LocalizacaoGeograficaEntidade PosicaoGeografica { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is AmigoEntidade))
                return false;

            AmigoEntidade other = obj as AmigoEntidade;
            if (other.Codigo == Codigo)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return Codigo.GetHashCode();
        }
    }
}
