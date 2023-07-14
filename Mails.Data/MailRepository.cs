using Mails.Data;
using Mails.Entities;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace Mails.Data
{
    public class MailRepository
    {
        private MailsContext _context;      
        public MailRepository(MailsContext context)
        {
            _context = context;
        }
        
        private List<Mail> GetOrderedMails()
        {
            var mails = _context.Mails.OrderByDescending(e => e.Date);
            return mails.ToList();
        }
        
        public List<Mail> GetInbox(string email)
        {
            var result = from m in GetOrderedMails()
                         where m.Receiver.Contains(email)
                         select m;
            return result.ToList();
        }
        
        public Mail GetById(int id)
        {
            var mail = _context.Mails.FirstOrDefault(x => x.MailId == id);
            return mail;
        }
        
        public List<Mail> GetOutbox(string email)
        {
            var result = from m in GetOrderedMails()
                         where m.SenderEmail.Contains(email)
                         select m;
            return result.ToList();
        }
        
        
        public void NewMail (Mail mail)
        {
            _context.Mails.Add(mail);
            _context.SaveChanges();
        }
       
    }
}