using UnityEngine;

namespace Game
{
    public class Player : Character
    {
        [SerializeField] private int healthPoint = 3;
        [SerializeField] private Eye eye;
        [SerializeField] private Ear ear;
        [SerializeField] private float adjustInterval = 0.2f;

        private bool isHoldingEye;
        private bool isHoldingEar;
        private float adjustTimer;

        protected override void Start()
        {
            base.Start();
            while (healthPoint-- > 1)
            {
                SpendPoint(ear, eye);
            }
        }

        private void Update()
        {
            if (!isHoldingEye && !isHoldingEar) return;

            adjustTimer -= Time.deltaTime;
            if (adjustTimer > 0) return;

            bool canAdjust = false;

            if (isHoldingEye)
            {
                canAdjust = SpendPoint(ear, eye);
            }
            else if (isHoldingEar)
            {
                canAdjust = SpendPoint(eye, ear);
            }

            if (canAdjust)
            {
                adjustTimer = adjustInterval;
            }
        }

        public void Die() => SceneLoader.Instance.ReloadScene();

        public void Win() => SceneLoader.Instance.LoadScene("Main Menu Scene");

        private bool SpendPoint(Sensor donor, Sensor receiver)
        {
            if (healthPoint > 0)
            {
                receiver.AdjustHealthiness(+1);
                donor.AdjustHealthiness(-1);
                healthPoint--;
                return true;
            }
            else if (donor.TryDonate(1))
            {
                receiver.AdjustHealthiness(+1);
                return true;
            }

            return false;
        }

        public void OnEyeButtonDown()
        {
            isHoldingEye = true;
            adjustTimer = 0f;
        }

        public void OnEyeButtonUp() => isHoldingEye = false;

        public void OnEarButtonDown()
        {
            isHoldingEar = true;
            adjustTimer = 0f;
        }

        public void OnEarButtonUp() => isHoldingEar = false;
    }
}
