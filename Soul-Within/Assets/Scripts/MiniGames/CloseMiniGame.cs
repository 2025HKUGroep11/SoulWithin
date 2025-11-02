using UnityEngine;

namespace MiniGames
{
    public class CloseMiniGame : MonoBehaviour
    {
        public void DisableMiniGame()
        {
            GameManager.instance.EndMiniGame();
        }
    }
}
