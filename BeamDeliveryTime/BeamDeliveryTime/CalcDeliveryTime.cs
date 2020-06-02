using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.Generic;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using System.Reflection;

namespace VMS.TPS
{
    public class Script
    {
        public Script()
        {
        }

        public void Execute(ScriptContext context)
        {
            //var plan = context.PlanSetup;

            var assemblypath = @"U:\Visual Studio 2013\Projects\BeamDeliveryTime\BeamDeliveryTime\bin\Release\BeamDeliveryTime.exe";
            var assem = Assembly.UnsafeLoadFrom(assemblypath);
            var script = Activator.CreateInstanceFrom(assemblypath, "BeamDeliveryTime.CalculatorXScript").Unwrap();
            var type = script.GetType();
            type.InvokeMember("Execute",
                BindingFlags.Default | BindingFlags.InvokeMethod,
                null,
                script,
                new object[] { context });
        }
    }
}