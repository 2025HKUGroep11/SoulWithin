using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Managers
{
    public class MiniGameManager : MonoBehaviour
    {
        public static MiniGameManager Instance { get; private set; }
        
        [SerializeField] GameObject simonSaysMiniGame;
        [SerializeField] GameObject beatMiniGame;
        
        private Dictionary<PrerequisiteMiniGames, bool> _completedMiniGames = new Dictionary<PrerequisiteMiniGames, bool>();
        
        public GameObject SimonSaysMiniGame { get => simonSaysMiniGame; private set => simonSaysMiniGame = value; }
        public GameObject BeatMiniGame { get => beatMiniGame; private set => beatMiniGame = value; }

        public Action onPrerequisiteMiniGamesCompleted;
        private void Awake() => AssignInstance();

        private void Start() => FillPrerequisiteMiniGames();
        public void ToggleSimonSays(bool isEnabled) => ToggleMiniGame(simonSaysMiniGame, isEnabled);
        
        public void ToggleBeatGame(bool isEnabled) => ToggleMiniGame(beatMiniGame, isEnabled);
        
        
        public void CompleteMiniGame(PrerequisiteMiniGames game, bool isCompleted)
        {
            if (!_completedMiniGames.ContainsKey(game))
            {
                Debug.LogError($"{game} is not added to _completedMiniGames dictionary");
                return;
            }
            _completedMiniGames[game] = isCompleted;

            foreach (var miniGame in _completedMiniGames)
            {
                if (miniGame.Value == false) return;
            }
            onPrerequisiteMiniGamesCompleted?.Invoke();
        }
        
        private void ToggleMiniGame(GameObject miniGame, bool isEnabled)
        {
            miniGame.SetActive(isEnabled);
            GameManager.Instance.ToggleMainGame(!isEnabled);
        }
        
        private void FillPrerequisiteMiniGames()
        {
            var miniGames = Enum.GetValues(typeof(PrerequisiteMiniGames));
            foreach (var miniGame in miniGames)
            {
                _completedMiniGames.Add((PrerequisiteMiniGames)miniGame, false);
            }
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
