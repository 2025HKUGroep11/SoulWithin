using System;
using Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Enviroment
{
    public class OnMiniGamesCompletedTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent onMiniGamesCompleted;
        private void Start() => MiniGameManager.Instance.onPrerequisiteMiniGamesCompleted += OnMiniGamesCompleted;

        private void OnDestroy() => MiniGameManager.Instance.onPrerequisiteMiniGamesCompleted -= OnMiniGamesCompleted;

        private void OnMiniGamesCompleted()
        {
            onMiniGamesCompleted?. Invoke();
        }
    }
}
