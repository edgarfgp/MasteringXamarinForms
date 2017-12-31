using System;
using System.Collections.Generic;
using System.Text;

namespace Paperboy.IServices
{
    public enum DeviceOrientations
    {
        Undefined,
        Landscape,
        Portrait
    }

    public interface IDeviceOrientation
    {
        DeviceOrientations GetOrientation();
    }
}
