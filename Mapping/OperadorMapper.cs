using Model;

namespace Mapping
{
    class OperadorMapper : BaseMapping<Operador>
    {
        public OperadorMapper()
        {
            this.HasKey(x => x.OperadorId);
        }
    }
}
