using UnityEngine;

namespace Game.UI
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private PlayerMovement playerMovement;

        private void Start()
        {
            if (player == null) player = FindAnyObjectByType<Player>();
            if (playerMovement == null) playerMovement = FindAnyObjectByType<PlayerMovement>();
        }

        public void OnMoveLeftButtonDown() => playerMovement?.OnLeftButtonDown();
        public void OnMoveLeftButtonUp() => playerMovement?.OnLeftButtonUp();

        public void OnMoveRightButtonDown() => playerMovement?.OnRightButtonDown();
        public void OnMoveRightButtonUp() => playerMovement?.OnRightButtonUp();

        public void OnJumpButtonClick() => playerMovement?.OnJumpButton();

        public void OnEyeButtonDown() => player?.OnEyeButtonDown();
        public void OnEyeButtonUp() => player?.OnEyeButtonUp();

        public void OnEarButtonDown() => player?.OnEarButtonDown();
        public void OnEarButtonUp() => player?.OnEarButtonUp();

    }
}
