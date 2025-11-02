using UnityEngine;

namespace Enviroment
{
    public class ToggleBackground : MonoBehaviour
    {
        [SerializeField] GameObject background;
        [SerializeField] GameObject newBackground;

        private bool _backgroundIsEnabled;

        public void SwapBackgrounds()
        {
            newBackground.SetActive(_backgroundIsEnabled);
            background.SetActive(!_backgroundIsEnabled);
            _backgroundIsEnabled = !_backgroundIsEnabled;
        }
    }
}
