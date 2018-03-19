using Model;

namespace Mapping
{
    class RecuperacaoSenhaMapper : BaseMapping<RecuperacaoSenha>
    {
        public RecuperacaoSenhaMapper()
        {
            this.HasKey(x => x.RecuperacaoSenhaId);
        }
    }
}