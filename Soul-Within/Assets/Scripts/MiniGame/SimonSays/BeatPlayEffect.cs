using UnityEngine;

namespace MiniGame.SimonSays
{
    public class BeatPlayEffect : MonoBehaviour
    {
        [SerializeField] private SimonSaysManager simonSaysManager;
        [SerializeField] private SimonSaysBeats beat;
        [SerializeField] private Vector3 scaleSize;
        [SerializeField] private float scaleTime;
        [SerializeField] private LeanTweenType scaleEaseType;
        [SerializeField] private AudioSource audioSource;
        
        private Vector3 _originalScale;

        private void Awake()
        {
            AssignEvents();
            _originalScale = transform.localScale;
        }

        public void PlayBeat()
        {
            transform.localScale = _originalScale;
            LeanTween.scale(gameObject, scaleSize, scaleTime).setEase(scaleEaseType).setLoopPingPong(1);
            
            if (audioSource == null)
            {
                Debug.LogError("audioSource is null");
                return;
            }
            
            audioSource.Play();
        }

        private void AssignEvents()
        {
            if (simonSaysManager == null)
            {
                Debug.LogError("SimonSaysManager is null");
                return;
            }

            simonSaysManager.OnBeatShown.TryAdd(beat, PlayBeat);
        }
    }
}
