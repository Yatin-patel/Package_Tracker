using AutoMapper;
using PackageComponents.Models;
using PackageDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents
{
    public class UserService : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool ValidateUser(string User_Name, string Password)
        {
            using (var p = new PackageDAL.PackageTrackerDBEntities())
            {
                return p.Users.Where(u => u.User_Name == User_Name).FirstOrDefault().Password == Password;
            }
        }

    }
}
