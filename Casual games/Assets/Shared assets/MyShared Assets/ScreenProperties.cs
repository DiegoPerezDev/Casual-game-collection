using UnityEngine;
using UnityEngine.UI;

public class ScreenProperties
{
    private Vector2 resolution = new Vector2(1080, 2340); // Samsung Galaxy A50 resolution
 
    public void SetScreenOrientation(ScreenOrientation orientation, bool enableRotation)
    {
        // Set portrait screen orientation
        Screen.orientation = orientation;

        // Block automatic rotation
        Screen.autorotateToLandscapeLeft      = enableRotation;
        Screen.autorotateToLandscapeRight     = enableRotation;
        Screen.autorotateToPortrait           = enableRotation;
        Screen.autorotateToPortraitUpsideDown = enableRotation;
    }

    public void SetScreenResolution(CanvasScaler canvasScaler, ScreenOrientation orientation)
    {
        if (orientation == ScreenOrientation.Portrait)
            canvasScaler.referenceResolution = resolution;
        else if (orientation == ScreenOrientation.LandscapeLeft || orientation == ScreenOrientation.LandscapeRight)
            canvasScaler.referenceResolution = new Vector2(resolution.y, resolution.x);
    }

}