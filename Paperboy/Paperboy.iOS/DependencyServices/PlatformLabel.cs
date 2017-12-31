using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Paperboy.iOS.DependencyServices;
using Paperboy.IServices;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformLabel))]
namespace Paperboy.iOS.DependencyServices
{
    public class PlatformLabel : IPlatformLabel
    {
        public PlatformLabel() { }

        public string GetLabel()
        {
            return "iOS";
        }

        public string GetLabel(string additionalLabel)
        {
            return $"{additionalLabel} iOS";
        }

        public string GetLabel(string additionalLabel, bool addVersion)
        {
            string label = (addVersion) ? label = $"{additionalLabel} iOS {GetOsVersion()}" :
                $"{additionalLabel} iOS";

            return label;
        }

        private string GetOsVersion()
        {
            return UIDevice.CurrentDevice.SystemVersion;
        }
    }
}