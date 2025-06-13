using UnityEngine;

namespace Game
{
    public class CameraShaker : MonoBehaviour
    {
        [SerializeField] private float defaultShakeDuration = 0.5f;
        [SerializeField] private float defaultShakeMagnitude = 0.2f;

        private Vector3 originalPosition;
        private float shakeTimer;
        private bool shaking;

        private void LateUpdate()
        {
            if (!shaking) return;

            if (shakeTimer > 0)
            {
                transform.localPosition = originalPosition + (Vector3)Random.insideUnitCircle * defaultShakeMagnitude;
                shakeTimer -= Time.deltaTime;
            }
            else
            {
                transform.localPosition = originalPosition;
                shaking = false;
            }
        }

        public void Shake(float duration = -1f, float magnitude = -1f)
        {
            if (!shaking)
                originalPosition = transform.localPosition;

            shakeTimer = (duration > 0f) ? duration : defaultShakeDuration;
            defaultShakeMagnitude = (magnitude > 0f) ? magnitude : defaultShakeMagnitude;
            shaking = true;
        }
    }
}
