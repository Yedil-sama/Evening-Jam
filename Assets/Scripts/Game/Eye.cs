using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Game
{
    public class Eye : Sensor
    {
        [SerializeField] private Volume volume;

        protected override void ApplyEffect()
        {
            if (volume.profile.TryGet(out Vignette vignette))
            {
                vignette.intensity.value = 1f - Sensitivity;
                Camera.main.orthographicSize = 1f + Sensitivity;
            }
        }
    }
}
