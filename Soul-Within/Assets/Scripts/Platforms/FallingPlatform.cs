using System;
using System.Collections;
using UnityEngine;

namespace Platforms
{
    public class FallingPlatform : MonoBehaviour
    {
        [SerializeField] private string playerTag;
        [SerializeField] private float waitUntilFallDuration;
        [SerializeField] private Transform wobbleLocation;
        [SerializeField] private LeanTweenType wobbleTweenType;
        [SerializeField] private int wobbleAmount;
        [SerializeField] private LeanTweenType fallingTweenType;
        [SerializeField] private float fallingDuration;
        [SerializeField] private Transform fallingLocation;
        [SerializeField] private float respawnDelay;
        [SerializeField] private float respawnDuration;
        [SerializeField] private LeanTweenType respawnTweenType;

        [SerializeField] private new Collider2D collider;
        [SerializeField] private GameObject visuals;
        
        private Vector2 _startPosition;
        private Vector2 _fallPosition;
        private Vector2 _wobblePosition;

        private void Start() => SavePositions();

        
        private void SavePositions()
        {
            _startPosition = transform.position;
            _fallPosition = fallingLocation.position;
            _wobblePosition = wobbleLocation.position;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(playerTag) && !visuals.LeanIsTweening()) StartCoroutine(FallingPlatformSequence());
        }

        private IEnumerator FallingPlatformSequence()
        {
            LeanTween.move(visuals, _wobblePosition, waitUntilFallDuration).setEase(wobbleTweenType).setLoopPingPong(wobbleAmount);
            while (visuals.LeanIsTweening())
            {
                yield return null;
            }
            
            collider.enabled = false;
            LeanTween.move(visuals, _fallPosition, fallingDuration).setEase(fallingTweenType);
            while (visuals.LeanIsTweening())
            {
                yield return null;
            }
            
            yield return new WaitForSeconds(respawnDelay);
            RespawnPlatform();
        }

        private void RespawnPlatform()
        {
            LeanTween.move(visuals, _startPosition, respawnDuration).setEase(respawnTweenType).setOnComplete(EnableCollision);
        }

        private void EnableCollision()
        {
            collider.enabled = true;
        }
    }
}
