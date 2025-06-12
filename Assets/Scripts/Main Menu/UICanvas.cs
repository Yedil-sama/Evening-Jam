using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    [RequireComponent(typeof(Canvas))]
    public class UICanvas<T> : MonoBehaviour where T : UICanvas<T>
    {
        public static T Instance { get; private set; }

        [Header("General")]
        [SerializeField] protected Image background;
        [SerializeField] private bool closeOnAwake;

        private Canvas canvas;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = (T)this;

            canvas = GetComponent<Canvas>();
            Open(!closeOnAwake);
        }

        public void Open(bool action)
        {
            canvas.enabled = action;

            if (background != null)
            {
                background.gameObject.SetActive(action);
                background.enabled = action;
            }
        }
    }
}
