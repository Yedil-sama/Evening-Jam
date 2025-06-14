using UnityEngine;

namespace Game
{
    public class JumpBooster : Booster
    {
        [SerializeField] private float boostForce = 10f;

        protected override void ApplyBoost(Rigidbody2D rb) => rb.AddForce(Vector2.up * boostForce, ForceMode2D.Impulse);
    }
}
