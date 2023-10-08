using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class UsersData
    {
        ClinicalEntities context = null;

        public UsersData()
        {
            context = new ClinicalEntities();
        }
        public bool AddUser(User p)
        {
            try
            {
                context.Users.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteUser(int id)
        {
            try
            {
                List<User> s = context.Users.ToList();
                User r = s.Find(pr => pr.UserId == id);

                context.Users.Remove(r);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public User GetUserByid(int id)
        {
            List<User> s = context.Users.ToList();
            User r = s.Find(pr => pr.UserId == id);
            return r;
        }
        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }
        public bool UpdateUser(int id, User p)
        {
            try
            {

                List<User> s = context.Users.ToList();
                User k = s.Find(pr => pr.UserId == id);

                k.UserId = p.UserId;
                k.Name = p.Name;
                k.Phone = p.Phone;
                k.Address = p.Address;
                k.DOB = p.DOB;
                k.Gender = p.Gender;
                k.Email = p.Password;
                k.IsActive = p.IsActive;
                k.RoleId = p.RoleId;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ForgetPasswprd(string email, string phoneno)
        {
            bool ans = false;
            var find = context.Users.ToList();
            foreach (var item in find)
            {
                if (item.Email == email && item.Phone == phoneno)
                {
                    ans = true;
                }
            }
            return ans;
        }
    }
}
