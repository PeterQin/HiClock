using Common.Application.Services;
using HiClock.Application.Services;
using HiClock.Application.ViewModels;
using HiClock.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using Common.Foundation;


namespace HiClock.Application.Controllers
{
    [Export(typeof(IModuleController)), Export, PartCreationPolicy(CreationPolicy.NonShared)]
    internal class ModuleController : IModuleController
    {
        private readonly CompositionContainer FContainer;             
        private readonly HiClockRoot FRoot;
        private readonly HiClockMainController FMainController;

        [ImportingConstructor]
        public ModuleController(CompositionContainer aContainer)
        {
            FContainer = aContainer;
            FRoot = new HiClockRoot();
            FMainController = FContainer.GetExportedValue<HiClockMainController>();
        }

        public void Initialize()
        {
            FRoot.Load();
            FMainController.Initialize(FRoot);        

        }        

        public void Run()
        {
            FMainController.Run();
        }
       
        public void Shutdown()
        {
            FRoot.Save();
            FMainController.Shutdown();            
        }

    }
}
