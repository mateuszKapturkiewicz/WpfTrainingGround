using MasteringWpf.Managers.Interfaces;
using MasteringWpf.Managers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MasteringWpf.DataModels.Enums;
using System.Windows.Media;

namespace MasteringWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            StateManager.Instance.RenderingTier = (RenderingTier)(RenderCapability.Tier >> 16);
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            DependencyManager.Instance.ClearRegistrations();
            //DependencyManagerAdvanced.Instance.RegisterAllInterfacesInAssemblyOf<IDataProvider>();
            //DependencyManagerAdvanced.Instance.RegisterAllInterfacesInAssemblyOf<IDataAsynchronyManager>();
            //DependencyManagerAdvanced.Instance.RegisterAllInterfacesInAssemblyOf<IUserViewModel>();
            //DependencyManager.Instance.Register<IDataProvider, ApplicationDataProvider>();
            DependencyManager.Instance.Register<IUiThreadManager, UiThreadManager>();
            //DependencyManager.Instance.Register<IUserViewModel, UserViewModel>();
        }
    }


}
