using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Collider2D))]
    public class DeathZone : MonoBehaviour
    {
        private readonly HashSet<Player> triggeredPlayers = new();

        private void Start()
        {
            if (TryGetComponent(out CharacterAnimator animator))
            {
                animator.Play("Idle");
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player player) && !triggeredPlayers.Contains(player))
            {
                triggeredPlayers.Add(player);
                player.Die();
            }
        }
    }
}
