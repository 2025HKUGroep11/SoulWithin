using UnityEngine;
using UnityEngine.Video;

namespace Video
{
    public class PlayVideo : MonoBehaviour
    {
        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private VideoClip videoClip;

        public void StartVideo(bool isLooping)
        {
            videoPlayer.isLooping = isLooping;
            videoPlayer.clip = videoClip;
            videoPlayer.Play();
        }
    }
}
