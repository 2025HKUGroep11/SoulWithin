using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private GameObject mainGame;
        [SerializeField] private GameObject miniGame;
        private void Awake() => AssignInstance();

        private void Start()
        {
            ToggleMainGame(true);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            mainGame = GameObject.Find("MainGame");
            ToggleMainGame(true);
        }

        public void ToggleMainGame(bool isEnabled)
        {
            if (mainGame == null) return;
            mainGame.SetActive(isEnabled);
        }
        
        private void AssignInstance()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }
    }
}
