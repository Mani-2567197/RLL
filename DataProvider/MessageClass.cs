using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class MessageClass : OurClass, Interfacerepo<Message>
    {
        public int Add(Message item)
        {
            context.Messages.Add(item);
            int res = context.SaveChanges();
            if (res > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetById(int id)
        {
            IEnumerable<Message> messages = context.Messages.Include("User").
               OrderByDescending(mess => mess.MessageTime).
               Where(mess => mess.RecieverId == id || mess.SenderId == id);
            return messages;
        }
        public IEnumerable<Message> GetBySenderIdAndRecieverId(int SenderId, int RecieverId)
        {
            IEnumerable<Message> messages = context.Messages.Include("User").
                OrderBy(mess => mess.MessageTime).
                Where(mess => (mess.RecieverId == RecieverId && mess.SenderId == SenderId) || (mess.RecieverId == SenderId && mess.SenderId == RecieverId));
            return messages;
        }
        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> Search(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Message item)
        {
            throw new NotImplementedException();
        }
        Message Interfacerepo<Message>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
