using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _mainGame;
    [SerializeField] private GameObject _miniGame;

    private bool _inMiniGame = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
}
