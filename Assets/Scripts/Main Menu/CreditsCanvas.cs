using UnityEngine;

namespace MainMenu
{
    public class CreditsCanvas : UICanvas<CreditsCanvas>
    {
        public void OnMenuButtonClick()
        {
            if (MenuCanvas.Instance == null) return;

            Open(false);
            MenuCanvas.Instance.Open(true);
        }
    }
}
