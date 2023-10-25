using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class UserClass : OurClass, Interfacerepo<User>
    {
        public int Add(User item)
        {
            context.Users.Add(item);
            int result = context.SaveChanges();
            if (result > 0)
            {
                return item.UserId;
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = context.Users.Include("Role").Where(user => user.IsActive == true)
                .OrderBy(user => user.Name).Select(user => user);
            return users;
        }
        public IEnumerable<User> GetAllPateint()
        {
            IEnumerable<User> result = context.Users.Include("Role")
                .Where(usr => usr.IsActive == true && usr.RoleId == 3)
                .OrderBy(usr => usr.Name)
                .Select(usr => usr);
            return result;
        }
        public IEnumerable<User> GetAllDoctor()
        {
            IEnumerable<User> result = context.Users.Include("Role")
                .Where(usr => usr.IsActive == true && usr.RoleId == 2)
                .OrderBy(usr => usr.Name)
                .Select(usr => usr);
            return result;
        }
        public User GetById(int id)
        {
            User result = context.Users.Include("Role")
                .Where(usr => usr.IsActive == true && usr.UserId == id)
                .OrderBy(usr => usr.Name)
                .Select(usr => usr).FirstOrDefault();
            return result;
        }
        public User GetByName(string name)
        {
            User result = context.Users.Include("Role")
                .Where(usr => usr.IsActive == true)
                .OrderBy(usr => usr.Name)
                .Select(usr => usr).FirstOrDefault();
            return result;
        }
        public IEnumerable<User> GetByNameAll(string name)
        {
            IEnumerable<User> result = context.Users.Include("Role")
                .Where(usr => usr.IsActive == true && usr.Name.ToLower().Contains(name.ToLower()))
                .OrderBy(usr => usr.Name);
            return result;
        }
        public string GetByIdName(int id)
        {
            string name = context.Users.Where(u => u.UserId == id).Select(u => u.Name).FirstOrDefault();
            return name;
        }
        public bool Remove(int id)
        {
            User dbuser = GetById(id);
            context.Users.Remove(dbuser);
            int result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<User> Search(string name)
        {
            IEnumerable<User> result = context.Users.Include("Role").Where(user => user.Name.Equals(name))
                .OrderBy(user => user.Name).Select(user => user);
            return result;
        }

        public bool Update(User item)
        {
            User user = GetById(item.UserId);
            user.Phone = item.Phone;
            user.Email = item.Email;
            user.Password = item.Password;
            int result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public User LoginUsingEmailAndPassword(string email, string password)
        {
            User user = context.Users
                .Include("Role")
                .OrderBy(u => u.UserId).
                Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            return user;
        }
        public User ChangePassword(string email, string newpassword, string confirmpassword)
        {

            User user = null;
            if (user != null)
            {
                user = context.Users
                  .Include("Role")
               .OrderBy(u => u.UserId).
               Where(u => u.Email == email).FirstOrDefault();
                if (newpassword == confirmpassword)
                {
                    user.Password = newpassword;
                    context.SaveChanges();
                }
            }
            else
            {
                user = null;
            }
            return user;
        }
    }
}
