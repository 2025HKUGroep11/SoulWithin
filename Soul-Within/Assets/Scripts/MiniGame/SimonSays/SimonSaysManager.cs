using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Managers;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame.SimonSays
{
    public class SimonSaysManager : MonoBehaviour
    {
        [SerializeField] private PrerequisiteMiniGames miniGame;
        
        [SerializeField] private float waitTimeBetweenBeats;
        [SerializeField] private float waitTimeBetweenRounds;
        [SerializeField] private List<SimonSaysBeats> beats = new List<SimonSaysBeats>();
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip correctSound;
        [SerializeField] private AudioClip wrongSound;
        
        private int _round;
        private int _step;
        private Dictionary<SimonSaysBeats, Action> _onBeatShown = new();

        public Dictionary<SimonSaysBeats, Action> OnBeatShown { get => _onBeatShown; set => _onBeatShown = value; }

        [SerializeField] UnityEvent onCompleteGame;

        private void Start()
        {
            StartCoroutine(ShowBeatPattern());
        }

        public void OnPressedBeat(int beatValue)
        {
            SimonSaysBeats beat = (SimonSaysBeats)beatValue;
            ContinueGame(beat);
        }

        private void ContinueGame(SimonSaysBeats beat)
        {
            if (beat != beats[_step])
            {
                ResetGame();
                return;
            }

            _step += 1;
            if (_step <= _round) { return; }

            StartCoroutine(PlayCorrectSound());
            _round += 1;
            _step = 0;
            if (_round == beats.Count)
            {
                StartCoroutine(CompleteGame());
                return;
            }
            
            StartCoroutine(ShowBeatPattern());
        }

        private void ResetGame()
        {
            audioSource.PlayOneShot(wrongSound);
            _round = 0;
            _step = 0;
            StartCoroutine(ShowBeatPattern());
        }
        
        private IEnumerator ShowBeatPattern()
        {
            Debug.Log("Showing beat pattern");
            yield return new WaitForSeconds(waitTimeBetweenRounds);
            for (int i = 0; i < _round + 1; i++)
            {
                SimonSaysBeats beat = beats[i];
                _onBeatShown[beat].Invoke();
                yield return new WaitForSeconds(waitTimeBetweenBeats);
            }
        }
        
        private IEnumerator PlayCorrectSound()
        {
            yield return new WaitForSeconds(waitTimeBetweenBeats);
            audioSource.PlayOneShot(correctSound);
        }
        
        private IEnumerator CompleteGame()
        {
            yield return new WaitForSeconds(waitTimeBetweenRounds);
            MiniGameManager.Instance.CompleteMiniGame(miniGame, true);
            onCompleteGame?.Invoke();
        }
    }
}
