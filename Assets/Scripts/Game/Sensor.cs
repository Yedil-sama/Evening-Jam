using UnityEngine;

namespace Game
{
    public abstract class Sensor : MonoBehaviour
    {
        [SerializeField] private int healthiness = 3;
        [SerializeField] private float sensitivityMultiplier = 0.33f;

        public float Sensitivity => Mathf.Clamp01(healthiness * sensitivityMultiplier);
        public int Healthiness => healthiness;

        public virtual void AdjustHealthiness(int amount)
        {
            healthiness = Mathf.Clamp(healthiness + amount, 0, 3);
            ApplyEffect();
        }

        public virtual bool TryDonate(int amount)
        {
            if (healthiness >= amount)
            {
                healthiness -= amount;
                ApplyEffect();
                return true;
            }
            return false;
        }

        protected abstract void ApplyEffect();
    }
}
