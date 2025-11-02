using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace Video
{
    public class PlayVideo : MonoBehaviour
    {
        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private VideoClip videoClip;
        
        [SerializeField] public UnityEvent onVideoFinished;

        public void StartVideo(bool isLooping)
        {
            videoPlayer.isLooping = isLooping;
            videoPlayer.clip = videoClip;
            videoPlayer.Play();
            StartCoroutine(VideoDurationTracker((float)videoClip.length));
        }

        private IEnumerator VideoDurationTracker(float videoDuration)
        {
            yield return new WaitForSeconds(videoDuration);
            onVideoFinished?.Invoke();
        }
    }
}
