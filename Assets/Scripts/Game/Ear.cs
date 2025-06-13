using UnityEngine;

namespace Game
{
    public class Ear : Sensor
    {
        [SerializeField] private AudioSource source;

        protected override void ApplyEffect()
        {
            source.volume = Sensitivity;
        }
    }
}
