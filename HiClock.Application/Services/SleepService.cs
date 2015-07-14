using Common.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Waf.Applications;

namespace HiClock.Application.Services
{
    [Export, Export(typeof(ISleepService)), PartCreationPolicy(CreationPolicy.Shared)]
    internal class SleepService : DataModel, ISleepService
    {
        private Action FSleepAction;

        internal Action SleepAction
        {
            get { return FSleepAction; }
            set
            {
                if (FSleepAction != value)
                {
                    FSleepAction = value;
                }
            }
        }


        [ImportingConstructor]
        public SleepService()
        {

        }

        public void Sleep()
        {
            if (SleepAction != null)
            {
                SleepAction();
            }
        }


    }
}
