using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _mainGame;
    [SerializeField] private GameObject _miniGame;

    private bool _inMiniGame = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        ResetToMainGame();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _mainGame = GameObject.Find("MainGame");
        _miniGame = GameObject.Find("MiniGame");
        ResetToMainGame();
    }

    public void StartMiniGame()
    {
        _mainGame.SetActive(false);
        _miniGame.SetActive(true);
        _inMiniGame = true; 
    }

    public void EndMiniGame()
    {
        if (!_inMiniGame)
        {
            return;
        }
        _mainGame.SetActive(true);
        _miniGame.SetActive(false);
        _inMiniGame = false;
    }
    private void ResetToMainGame()
    {
        _inMiniGame = false;
        if (_mainGame != null)
        {
            _mainGame.SetActive(true);
        }
        if (_miniGame != null)
        {
            _miniGame.SetActive(false);
        }
    }
}
