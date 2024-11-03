using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel_234_CRM.Helper.DTO.Login;
using Vektorel_234_CRMWebUI.SessionHelper;

namespace Vektorel_234_CRM.Helper.SessionHelper
{
    public class SessionManager
    {
        
        public static LoginResponseDTO? loginResponseDTO 
        {
           
            get => AppHttpContext.Current.Session.GetObject<LoginResponseDTO>("LoginResponseDTO");
            set => AppHttpContext.Current.Session.SetObject("LoginResponseDTO", value);
           

          
        
        
        
        }
    }
}
