using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ChainOfResponsibility_Resources
{
    // Запрос доступа

    public class FileAccessRequest
    {
        public string FileName { get; set; }
        public string UserRole { get; set; }

        public FileAccessRequest(string fileName, string userRole)
        {
            FileName = fileName;
            UserRole = userRole;
        }
    }
}
