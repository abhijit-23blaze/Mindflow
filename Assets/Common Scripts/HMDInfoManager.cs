using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using DazuCode;

public class HMDInfoManager : MonoBehaviour
{
    private void Start()
    {
        Dz.Log("Is Device Active " + XRSettings.isDeviceActive);
        Dz.Log("Device Name is : " + XRSettings.loadedDeviceName);

        if (!XRSettings.isDeviceActive)
        {
            Dz.Log("No Headset plugged");
        }
        else if (XRSettings.isDeviceActive && XRSettings.loadedDeviceName == "MockHMD Display")
        {
            Dz.Log("Using MockHMD Display");
        }
        else 
        {
            Dz.Log("We have a headset " + XRSettings.loadedDeviceName);
        }
    }
}
