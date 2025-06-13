using UnityEngine;

namespace Game
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Vector2 boxSize = new Vector2(0.5f, 0.1f);
        [SerializeField] private LayerMask groundMask;

        public bool IsGrounded => Physics2D.OverlapBox(transform.position, boxSize, 0f, groundMask);

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, boxSize);
        }
#endif
    }
}
