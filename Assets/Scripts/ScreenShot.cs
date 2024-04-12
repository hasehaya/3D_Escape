using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ScreenShot :MonoBehaviour
{
    public void CaptureScreenshot()
    {
        string path = System.IO.Path.Combine(Application.dataPath, "Screenshots");
        System.IO.Directory.CreateDirectory(path);
        string currentCameraName = CameraManager.instance.currentCameraName;
        string resolution = Screen.width + "x" + Screen.height;
        string filename = resolution + "_" + currentCameraName + ".png";
        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(path, filename));
        Debug.Log("Screenshot saved to " + path);
    }
}
