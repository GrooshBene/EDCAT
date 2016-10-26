/*     INFINITY CODE 2013-2016      */
/*   http://www.infinity-code.com   */

using UnityEngine;
using UnityEngine.UI;

namespace InfinityCode.OnlineMapsExamples
{
    [AddComponentMenu("Infinity Code/Online Maps/Examples (API Usage)/RoteteCameraByGPSExample")]
    public class RoteteCameraByGPSExample : MonoBehaviour
    {

        public Slider sl;

        private void Start()
        {
            OnlineMapsLocationService.instance.OnCompassChanged += OnCompassChanged;
        }

        private void OnCompassChanged(float f)
        {
            if (Mathf.Abs(OnlineMapsTileSetControl.instance.cameraRotation.y - (f * 360)) > sl.value)
            {
                Debug.Log(f*360 + " || "+OnlineMapsTileSetControl.instance.cameraRotation.y);
                OnlineMapsTileSetControl.instance.cameraRotation.y = Mathf.Lerp(f * 360, OnlineMapsTileSetControl.instance.cameraRotation.y, Time.smoothDeltaTime);
            }
        }
    }
}