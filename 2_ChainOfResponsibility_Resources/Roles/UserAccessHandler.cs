using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2_ChainOfResponsibility_Resources.Roles
{
    // Проверка роли "Пользователь"

    public class UserAccessHandler : AccessHandler
    {
        public override void Handle(FileAccessRequest request)
        {
            if (request.UserRole == "User")
            {
                MessageBox.Show($"Пользователь имеет ограниченный доступ к файлу: {request.FileName}");
            }
            else if (Successor != null)
            {
                Successor.Handle(request);
            }
            else
            {
                MessageBox.Show($"Доступ запрещен для роли {request.UserRole}");
            }
        }
    }
}
