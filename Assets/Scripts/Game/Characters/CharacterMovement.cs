using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField, Tooltip(MOVEMENT_TOOLTIP)] protected float moveSpeed = 2f;
        [SerializeField, Tooltip(MOVEMENT_TOOLTIP)] protected float jumpForce = 2f;
        [SerializeField] protected GroundChecker groundChecker;

        protected Vector2 movementInput;
        protected Rigidbody2D rb;
        protected CharacterAnimator animator;

        private float postJumpTimer;
        private const string MOVEMENT_TOOLTIP = "If this object has Character component, this field will be overwritten by it.";
        private const float POST_JUMP_DELAY = 0.1f;
        private Vector2 externalVelocity;

        protected virtual void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<CharacterAnimator>();

            if (TryGetComponent(out Character owner))
            {
                moveSpeed = owner.MoveSpeed;
                jumpForce = owner.JumpForce;
            }
        }

        protected virtual void FixedUpdate()
        {
            if (postJumpTimer > 0f)
                postJumpTimer -= Time.fixedDeltaTime;

            Move();
        }

        protected virtual void Move()
        {
            Vector2 baseVelocity = new Vector2(movementInput.x * moveSpeed, rb.linearVelocity.y);
            rb.linearVelocity = baseVelocity + new Vector2(externalVelocity.x, 0f);

            externalVelocity.x = 0f;

            if (animator != null)
            {
                animator.Flip(movementInput.x);

                if (postJumpTimer <= 0f && groundChecker != null && groundChecker.IsGrounded)
                {
                    if (movementInput.x != 0) animator.Play("Run");
                    else if (movementInput.y == 0) animator.Play("Idle");
                }
            }
        }

        public void AddExternalVelocity(Vector2 velocity) => externalVelocity += velocity;

        public virtual void SetDirection(Vector2 dir) => movementInput = dir;

        public virtual bool TryJump()
        {
            if (groundChecker == null || !groundChecker.IsGrounded) return false;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            animator?.Play("Jump");

            postJumpTimer = POST_JUMP_DELAY;

            return true;
        }
    }
}
