using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ThreeD_Dodger
{
    public class ScreenOrientation : MonoBehaviour
    {
        [SerializeField] private CanvasScaler canvasScaler;

        void Start()
        {
            // force screen orientation
            Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
            canvasScaler.referenceResolution = new Vector2(1080, 1920); // Portrait

            // Block automatic rotation
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
        }
    }
}