using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetListInbox(string parametre)
        {
            return _messageDal.List(x => x.ReceiverMail == parametre);
        }

        public List<Message> GetListSendbox(string parametre)
        {
            return _messageDal.List(x => x.SenderMail == parametre);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.Id == id);
        }

        public void Add(Message message)
        {
            _messageDal.Insert(message);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        //public List<Message> GetAll()
        //{
        //    return _messageDal.List(x=>x.ReceiverMail=="admin@gmail.com");
        //}
    }
}
