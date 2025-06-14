using UnityEngine;

namespace Game
{
    public class PushBooster : Booster
    {
        [SerializeField] private float force = 10f;
        [SerializeField] private bool useRigidDirection = true;

        protected override void ApplyBoost(Rigidbody2D rb)
        {
            Vector2 pushDirection = Vector2.right;

            if (useRigidDirection)
            {
                float horizontalSpeed = rb.linearVelocity.x;

                if (Mathf.Abs(horizontalSpeed) > 0.1f)
                    pushDirection = new Vector2(Mathf.Sign(horizontalSpeed), 0f);
            }

            if (rb.TryGetComponent(out CharacterMovement movement))
                movement.AddExternalVelocity(pushDirection.normalized * force);
            else
                rb.linearVelocity += pushDirection.normalized * force;
        }
    }
}
