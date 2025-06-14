using UnityEngine;
using System.Collections.Generic;

namespace Game
{
    public class Ear : Sensor
    {
        [SerializeField] private GameObject audioRoot;
        private List<AudioSource> sources = new();

        private void Awake()
        {
            if (audioRoot == null)
            {
                Debug.LogWarning("Ear: Audio root is not assigned.");
                return;
            }

            sources.AddRange(audioRoot.GetComponentsInChildren<AudioSource>());
        }

        protected override void ApplyEffect()
        {
            foreach (AudioSource source in sources)
            {
                if (source != null)
                    source.volume = Sensitivity;
            }
        }
    }
}
