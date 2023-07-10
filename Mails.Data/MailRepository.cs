using Mails.Data;
using Mails.Entities;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace Mails.Data
{
    public class MailRepository
    {
        private MailsContext _context;
        //construcctor asociado al mail loggeado
        public MailRepository(MailsContext context)
        {
            _context = context;
        }
        //General: Ordena por fecha mas reciente los correos
        private List<Mail> GetOrderedMails()
        {
            var mails = _context.Mails.OrderByDescending(e => e.Date);
            return mails.ToList();
        }
        //General: Trae todos los correos del inbox del Email loggeado
        public List<Mail> GetInbox(string email)
        {
            var result = from m in GetOrderedMails()
                         where m.Receiver.Contains(email)
                         select m;
            return result.ToList();
        }
        //Trae un correo filtrando busqueda por ID
        public Mail GetById(int id)
        {
            var mail = _context.Mails.FirstOrDefault(x => x.MailId == id);
            return mail;
        }
        //Treae la bandeja de salida filtrando por el Email loggeado
        public List<Mail> GetOutbox(string email)
        {
            var result = from m in GetOrderedMails()
                         where m.SenderEmail.Contains(email)
                         select m;
            return result.ToList();
        }
        
        //Crea un nuevo correo y almacena en DB
        public void NewMail (Mail mail)
        {
            _context.Mails.Add(mail);
            _context.SaveChanges();
        }
       
    }
}