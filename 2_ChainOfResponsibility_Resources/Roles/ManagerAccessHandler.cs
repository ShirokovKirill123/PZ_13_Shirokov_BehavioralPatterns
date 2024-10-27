using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2_ChainOfResponsibility_Resources.Roles
{
    // Проверка роли "Менеджер"

    public class ManagerAccessHandler : AccessHandler
    {
        public override void Handle(FileAccessRequest request)
        {
            if (request.UserRole == "Manager")
            {
                MessageBox.Show($"Менеджер имеет доступ к файлу для чтения: {request.FileName}");
            }
            else if (Successor != null)
            {
                Successor.Handle(request);
            }
        }
    }
}
