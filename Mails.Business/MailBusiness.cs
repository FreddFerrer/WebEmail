using Mails.Data;
using Mails.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Mails.Business
{
    public class MailBusiness
    {
        private MailRepository _mailRepository;

        public MailBusiness(MailRepository mailRepository) 
        { 
            _mailRepository = mailRepository;
        }

        
        public Mail GetById(int id)
        {
            return _mailRepository.GetById(id);
        }
        public void NewMail(Mail mail)
        {
            _mailRepository.NewMail(mail);
        }
        
        public List<Mail> GetInbox(string email)
        {
            return _mailRepository.GetInbox(email);
        }
        public List<Mail> GetOutbox(string email)
        {
            return _mailRepository.GetOutbox(email);
        }
        
    }
}