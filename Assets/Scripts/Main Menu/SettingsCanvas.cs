using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class SettingsCanvas : UICanvas<SettingsCanvas>
    {
        [Header("Sound UI")]
        [SerializeField] private Slider soundSlider;
        [SerializeField] private Image soundIcon;
        [SerializeField] private Sprite soundOnSprite;
        [SerializeField] private Sprite soundOffSprite;

        private const string SOUND_PREF_KEY = "Sound";

        private void Start()
        {
            int savedVolume = PlayerPrefs.GetInt(SOUND_PREF_KEY, 100);
            soundSlider.SetValueWithoutNotify(savedVolume);
            UpdateSoundIcon(savedVolume);
        }

        private void OnEnable()
        {
            soundSlider.onValueChanged.AddListener(OnSliderValueChanged);
        }

        private void OnDisable()
        {
            soundSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }

        public void OnMenuButtonClick()
        {
            if (MenuCanvas.Instance == null) return;

            Open(false);
            MenuCanvas.Instance.Open(true);
        }

        public void OnSoundButtonClick()
        {
            int currentVolume = PlayerPrefs.GetInt(SOUND_PREF_KEY, 100);
            int newVolume = currentVolume > 0 ? 0 : 100;

            PlayerPrefs.SetInt(SOUND_PREF_KEY, newVolume);
            PlayerPrefs.Save();

            soundSlider.SetValueWithoutNotify(newVolume);
            UpdateSoundIcon(newVolume);
        }

        public void OnSliderValueChanged(float value)
        {
            int volume = (int)(value * 100);
            PlayerPrefs.SetInt(SOUND_PREF_KEY, volume);
            PlayerPrefs.Save();

            UpdateSoundIcon(volume);
        }

        private void UpdateSoundIcon(int volume)
        {
            if (soundIcon == null) return;
            soundIcon.sprite = (volume > 0) ? soundOnSprite : soundOffSprite;
        }
    }
}
