using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D), typeof(CharacterAnimator))]
    public class Character : MonoBehaviour
    {
        [SerializeField] protected float moveSpeed = 2f;
        public float MoveSpeed => moveSpeed;

        [SerializeField] protected float jumpForce = 2f;
        public float JumpForce => jumpForce;

        protected Rigidbody2D rb;
        protected Collider2D hitbox;
        protected CharacterAnimator animator;

        protected virtual void Start()
        {
            hitbox = GetComponent<Collider2D>();
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<CharacterAnimator>();
        }

        public virtual void Move(float direction) => rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

        public virtual void Jump()
        {
            if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
