using ActionMailer.Net.Mvc;
using Admin.WebCommon;

namespace Admin.Controllers
{
    public class MailController : MailerBase, IMailSender
    {
        const string SUBJECT = "Recuperação de Senha - Admin";

        public void Enviar(ViewModels.EmailEnviadoViewModel emailEnviado)
        {
            this.To.Add(emailEnviado.Email);
            this.Subject = SUBJECT;
            this.Email("RecuperacaoSenha", emailEnviado).Deliver();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (MailSender != null)
                {
                    MailSender.Dispose();
                    MailSender = null;
                }
            }
        }

    }
}