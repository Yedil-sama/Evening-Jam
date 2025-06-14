using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Collider2D))]
    public class WinZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.Win();
            }
        }
    }
}
