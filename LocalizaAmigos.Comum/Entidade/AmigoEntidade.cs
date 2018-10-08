using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizaAmigos.Comum.Entidade
{
    public class AmigoEntidade
    {
        public AmigoEntidade() { }

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
