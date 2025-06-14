using UnityEngine;

namespace Game
{
    public class LevitationBooster : Booster
    {
        [SerializeField] private float levitationSpeed = 2f;

        protected override void ApplyBoost(Rigidbody2D rb) => rb.linearVelocity = new Vector2(rb.linearVelocity.x, levitationSpeed);
    }
}
