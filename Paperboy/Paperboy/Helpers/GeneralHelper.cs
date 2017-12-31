using Paperboy.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Paperboy.Helpers
{
    public class GeneralHelper
    {
        //    public static void Speak(string text)
        //    {
        //       DependencyService.Get<ITextSpeecher>().Speak(text);
        //    }

        public static DeviceOrientations GetOrientation()
        {
            var orientation = DependencyService.Get<IDeviceOrientation>().GetOrientation();

            return orientation;
        }

        public static string GetLabel()
        {
            string label = DependencyService.Get<IPlatformLabel>().GetLabel();

            return label;
        }

        public static string GetLabel(string additionalLabel)
        {
            string label = DependencyService.Get<IPlatformLabel>().GetLabel(additionalLabel);

            return label;
        }

        public static string GetLabel(string additionalLabel, bool addVersion)
        {
            string label = DependencyService.Get<IPlatformLabel>().GetLabel(additionalLabel, addVersion);

            return label;
        }
    }

}

