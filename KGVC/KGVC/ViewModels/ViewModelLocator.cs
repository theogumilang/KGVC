using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;


namespace KGVC.ViewModels
{
    public class ViewModelLocator
    {
        public LoginPageViewModel LoginPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginPageViewModel>();
            }
        }
    }
}
