using WWW.ViewModels.Response;

namespace WWW.ViewModels.Validation
{
    public interface IMailSender
    {
        void Enviar(EmailEnviadoViewModel emailEnviado);
    }
}