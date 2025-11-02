using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class SwitchScene : MonoBehaviour
    {
        public void SwapScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
