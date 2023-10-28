using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotTaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Screenshot"))
        {
            TakeScreenshot();
        }
    }

    public void TakeScreenshot()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        try
        {
            string directory = Application.dataPath + "/../Screenshots/";
            string fileName = "Screenshot-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-ffff") + ".png";
            Debug.LogWarning("Screenshot Path: \'" + directory + fileName + "\'");
            System.IO.Directory.CreateDirectory(directory);
            ScreenCapture.CaptureScreenshot(directory + fileName);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
#endif
    }
}
