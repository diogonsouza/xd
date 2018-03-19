using Admin.ViewModels;

namespace Admin.WebCommon
{
    public interface IMailSender
    {
        void Enviar(EmailEnviadoViewModel emailEnviado);
    }
}