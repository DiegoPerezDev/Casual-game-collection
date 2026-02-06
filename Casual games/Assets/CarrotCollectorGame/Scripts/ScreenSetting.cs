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
            // force portrait screen orientation
            Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
            canvasScaler.referenceResolution = new Vector2(1080, 1920);

            // Block automatic rotation
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
        }
    }
}