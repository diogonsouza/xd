using ActionMailer.Net.Mvc;
using WWW.ViewModels.Response;
using WWW.ViewModels.Validation;

namespace WWW.Controllers
{
    public class MailController : MailerBase, IMailSender
    {
        const string SUBJECT = "Ativar Cadastro";

        public void Enviar(ViewModels.Response.EmailEnviadoViewModel emailEnviado)
        {
            this.To.Add(emailEnviado.Email);
            this.Subject = SUBJECT;
            this.Email("Ativacao", emailEnviado).Deliver();
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