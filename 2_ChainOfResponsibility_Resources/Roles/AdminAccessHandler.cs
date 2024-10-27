using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2_ChainOfResponsibility_Resources.Roles
{
    // Проверка роли "Администратор"

    public class AdminAccessHandler : AccessHandler
    {
        public override void Handle(FileAccessRequest request)
        {
            if (request.UserRole == "Admin")
            {
                MessageBox.Show($"Администратор имеет полный доступ к файлу: {request.FileName}");
            }
            else if (Successor != null)
            {
                Successor.Handle(request);
            }
        }
    }
}
