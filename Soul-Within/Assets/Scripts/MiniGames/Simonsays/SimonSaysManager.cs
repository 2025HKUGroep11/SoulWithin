using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MiniGames.Simonsays
{
    public class SimonSaysManager : MonoBehaviour
    {
        [SerializeField] private float waitTimeBetweenBeats;
        [SerializeField] private List<SimonSaysBeats> beats = new List<SimonSaysBeats>();
        
        private int _round;
        private int _step;
        
        public UnityEvent<SimonSaysBeats> showBeat;

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
            if (_step <= _round)
            {
                //Debug.Log("step completed, round is not");
                return;
            }
            _round += 1;
            _step = 0;
            //Debug.Log("round completed");
            StartCoroutine(ShowBeatPattern());
            if (_round == beats.Count) CompleteGame();
        }

        private IEnumerator ShowBeatPattern()
        {
            for (int i = 0; i < _round; i++)
            {
                SimonSaysBeats beat = beats[i];
                showBeat.Invoke(beat);
                yield return new WaitForSeconds(waitTimeBetweenBeats);
            }
        }

        private void CompleteGame()
        {
            Debug.Log("Game Complete");
        }

        private void ResetGame()
        {
            Debug.Log("Game Reset");
            _round = 0;
            _step = 0;
            StartCoroutine(ShowBeatPattern());
        }
    }
}
