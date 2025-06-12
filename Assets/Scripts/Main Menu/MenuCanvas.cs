using UnityEngine;

namespace MainMenu
{
    public class MenuCanvas : UICanvas<MenuCanvas>
    {
        public void OnPlayButtonClick()
        {

        }

        public void OnSettingsButtonClick()
        {
            if (SettingsCanvas.Instance == null)  return;

            Open(false);
            SettingsCanvas.Instance.Open(true);
        }

        public void OnCreditsButtonClick()
        {
            if (CreditsCanvas.Instance == null) return;

            Open(false);
            CreditsCanvas.Instance.Open(true);
        }
    }
}
