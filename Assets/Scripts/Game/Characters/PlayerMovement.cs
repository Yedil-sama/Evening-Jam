using UnityEngine;

namespace Game
{
    public class PlayerMovement : CharacterMovement
    {
        private bool moveLeft;
        private bool moveRight;
        private bool jumpRequest;

        private void Update()
        {
            Vector2 input = Vector2.zero;

            if (moveLeft) input.x = -1;
            if (moveRight) input.x = 1;

            if (jumpRequest)
            {
                if (TryJump()) input.y = 1;
                else input.y = 0;

                jumpRequest = false;
            }

            SetDirection(input.normalized);
        }

        public void OnLeftButtonDown() => moveLeft = true;
        public void OnLeftButtonUp() => moveLeft = false;

        public void OnRightButtonDown() => moveRight = true;
        public void OnRightButtonUp() => moveRight = false;

        public void OnJumpButton() => jumpRequest = true;
    }
}
