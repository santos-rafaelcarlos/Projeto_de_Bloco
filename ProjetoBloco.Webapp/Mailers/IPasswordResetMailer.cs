using Mvc.Mailer;
using ProjetoBloco.Webapp.Mailers.Models;

namespace ProjetoBloco.Webapp.Mailers
{ 
    public interface IPasswordResetMailer
    {
			MvcMailMessage PasswordReset(MailerModel model);
	}
}