using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CarrotCollector
{
    public class ScreenSetting : MonoBehaviour
    {
        [SerializeField] private CanvasScaler canvasScaler;
        void Start()
        {
            // force landscape screen orientation
            Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
            canvasScaler.referenceResolution = new Vector2(1920, 1080); // Landscape

            // Block automatic rotation
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
        }
    }
}