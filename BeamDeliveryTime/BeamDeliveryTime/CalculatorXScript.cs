using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using System.Windows.Forms; // have to add this reference
using System.IO;
using System.Reflection;
using System.Drawing; // have to add this reference

namespace BeamDeliveryTime
{
    class CalculatorXScript : MarshalByRefObject
    {
        public void Execute(VMS.TPS.Common.Model.API.ScriptContext context) // Eclipse expects context here System.Windows.Window window
        {
            if (context.Patient == null || context.PlanSetup == null || context.PlanSetup.Dose == null || context.StructureSet == null)
            {
                throw new ApplicationException("Please load a patient, structure set, and a plan that has dose calculated!");
            }

            var plan = context.PlanSetup;

            Window deliverywpf = new BeamDeliveryTime.MainWindow(plan);

            deliverywpf.Show();
            deliverywpf.Activate();
            deliverywpf.Topmost = true;

        }
    }
}
