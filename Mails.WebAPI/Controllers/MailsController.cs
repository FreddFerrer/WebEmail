using Mails.Data;
using Mails.Business;
using Mails.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mails.WebAPI.Controllers
{
    
    [Route("api/mails")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private MailBusiness _mailBusiness;
        public MailsController(MailBusiness mail) 
        {
            _mailBusiness = mail;
        }

        
        [HttpGet("{id}")]
        public Mail GetById(int id)
        {
            return _mailBusiness.GetById(id);
        }
        [HttpPost]
        public void NewMail(Mail mail)
        {
            _mailBusiness.NewMail(mail);
        }
        
        [HttpGet("all/inbox/{email}")]
        public List<Mail> GetInbox(string email)
        {
            return _mailBusiness.GetInbox(email);
        }
        [HttpGet("all/outbox/{email}")]
        public List<Mail> GetOutbox(string email)
        {
            return _mailBusiness.GetOutbox(email);
        }
        
    }
}
