using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class CharacterAnimation
    {
        public string name;
        public Sprite[] frames;
        public float frameRate = 12f;
        public bool loop = true;
    }
}
