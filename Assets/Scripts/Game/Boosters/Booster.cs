using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Booster : MonoBehaviour
    {
        [SerializeField] private BoosterMode mode = BoosterMode.Repeatable;
        [SerializeField] private float cooldown = 1f;

        private readonly Dictionary<Rigidbody2D, float> cooldownTimers = new();

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Rigidbody2D rb)) return;

            switch (mode)
            {
                case BoosterMode.Continuous:
                    ApplyBoost(rb);
                    break;

                case BoosterMode.Repeatable:
                    if (!cooldownTimers.ContainsKey(rb) || Time.time >= cooldownTimers[rb])
                    {
                        ApplyBoost(rb);
                        cooldownTimers[rb] = Time.time + cooldown;
                    }
                    break;
            }
        }

        protected abstract void ApplyBoost(Rigidbody2D rb);
    }
}
