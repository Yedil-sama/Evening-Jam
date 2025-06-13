using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private List<CharacterAnimation> animations;

        private int currentFrame;
        private float timer;
        private string currentState => currentAnimation?.name;
        private SpriteRenderer spriteRenderer;
        private CharacterAnimation currentAnimation;

        private void Start() => spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        private void Update()
        {
            if (currentAnimation == null || currentAnimation.frames.Length == 0) return;

            timer += Time.deltaTime;
            float frameTime = 1f / currentAnimation.frameRate;

            if (timer >= frameTime)
            {
                timer -= frameTime;
                currentFrame++;

                if (currentFrame >= currentAnimation.frames.Length)
                {
                    if (currentAnimation.loop)
                        currentFrame = 0;
                    else
                        currentFrame = currentAnimation.frames.Length - 1;
                }

                spriteRenderer.sprite = currentAnimation.frames[currentFrame];
            }
        }

        public void Play(string animationName)
        {
            if (animationName == currentState) return;

            CharacterAnimation anim = animations.Find(a => a.name == animationName);
            if (anim != null && anim != currentAnimation)
            {
                currentAnimation = anim;
                currentFrame = 0;
                timer = 0f;
                spriteRenderer.sprite = currentAnimation.frames[0];
            }
        }

        public void Flip(float direction)
        {
            if (Mathf.Abs(direction) > 0.01f)
                spriteRenderer.flipX = direction < 0f;
        }
    }
}
