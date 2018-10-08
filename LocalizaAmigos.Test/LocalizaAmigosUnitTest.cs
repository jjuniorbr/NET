using System;
using System.Linq;
using LocalizaAmigos.Test.AcessoDados;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocalizaAmigos.Test
{
    [TestClass]
    public class LocalizaAmigosUnitTest
    {
        [TestMethod]
        public void PesquisarAmigoPorNome()
        {
            string nomeAmigo = "Paulo";

            AmigoEntidade objRetornoRecebido = new AmigoEntidade().listaAmigos.FirstOrDefault(x => x.Nome.ToLower() == nomeAmigo.ToLower());

            AmigoEntidade objRetornoesperado = new AmigoEntidade
            { Codigo = 1, Nome = "Henrique", PosicaoGeografica = new LocalizacaoGeograficaEntidade { Latitude = -22, Longitude = -43 } };

            Assert.AreEqual(objRetornoRecebido, objRetornoesperado, "Informação não cadastrada");

        }
    }
}
