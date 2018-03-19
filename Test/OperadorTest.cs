using Business.Interface;
using Fbiz.Framework.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class OperadorTest
    {
        //[TestMethod]
        //public void AoBuscarOperador_OperadorValido_RetornarComSucesso()
        //{
        //    var operadorBusiness = IoCWrapper.Container.Resolve<IOperadorBusiness>();

        //    var operador = operadorBusiness.Obter("admin");

        //    Assert.IsNotNull(operador);
        //}

        [TestMethod]
        public void AoBuscarOperador_OperadorInexistente_RetornarNulo()
        {
            var operadorBusiness = IoCWrapper.Container.Resolve<IOperadorBusiness>();

            var operador = operadorBusiness.Obter("xxx");

            Assert.IsNull(operador);
        }


        //[TestMethod]
        //public void AoAdicionarPaginacao_OperadoresValidos_RetornaNaoNulo()
        //{
        //    var TOTAL = 21;
        //    var operadorBusiness = IoCWrapper.Container.Resolve<IOperadorBusiness>();
        //    var operadorPassword = IoCWrapper.Container.Resolve<Rijndael>().Encode("159753");
        //    var operador = new Operador();

        //    for (int i = 0; i < TOTAL; i++)
        //    {
        //        operador = new Operador()
        //        {
        //            Nome = "Paginacao_" + i,
        //            Login = "paginacao_" + i + "@fbiz.com.br",
        //            Senha = operadorPassword,
        //            Ativo = true,
        //            DataCadastro = DateTime.Now
        //        };

        //        operadorBusiness.Add(operador);
        //    }
        //    operadorBusiness.Save();

        //    Assert.IsNotNull(operador);
        //}

        //[TestMethod]
        //public void AoRemoverPaginacao_OperadoresDeletados_RetornaNulo()
        //{
        //    var TOTAL = 21;
        //    var operadorBusiness = IoCWrapper.Container.Resolve<IOperadorBusiness>();
        //    var operador = new Operador();

        //    for (int i = 0; i < TOTAL; i++)
        //    {
        //        operador = operadorBusiness.Obter("paginacao_" + i + "@fbiz.com.br");

        //        if (operador == null)
        //            break;

        //        operadorBusiness.Remove(operador);
        //    }
        //    operadorBusiness.Save();

        //    Assert.IsNull(operador);
        //}
    }
}
