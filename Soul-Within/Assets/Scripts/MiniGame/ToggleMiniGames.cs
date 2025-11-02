using Managers;
using UnityEngine;

namespace MiniGame
{
    public class ToggleMiniGames : MonoBehaviour
    {
        public void ToggleSimonSays(bool isEnabled) => MiniGameManager.Instance.ToggleSimonSays(isEnabled);
        
        public void ToggleBeatGame(bool isEnabled) => MiniGameManager.Instance.ToggleBeatGame(isEnabled);
        
    }
}
