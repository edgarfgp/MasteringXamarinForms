using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Paperboy.iOS.DependencyServices;
using Paperboy.IServices;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceOrientation))]
namespace Paperboy.iOS.DependencyServices
{
    public class DeviceOrientation : IDeviceOrientation
    {
        public DeviceOrientation() { }

        public DeviceOrientations GetOrientation()
        {
            var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
            bool isPortrait = currentOrientation == UIInterfaceOrientation.Portrait
                || currentOrientation == UIInterfaceOrientation.PortraitUpsideDown;

            return isPortrait ? DeviceOrientations.Portrait : DeviceOrientations.Landscape;
        }
    }
}