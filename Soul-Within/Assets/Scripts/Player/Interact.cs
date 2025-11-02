using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player
{
    public class Interact : MonoBehaviour
    {
        private bool _playerInRange = false;
        private PlayerControls inputControls;
 
        [SerializeField] UnityEvent onInteract;
        [SerializeField] private GameObject objectInteractionUI;
        [SerializeField] private string playerTag;

        private void Awake()
        {
            inputControls = new PlayerControls();
        }

        // Grabs input player controller
        private void OnEnable()
        {
            inputControls.Player.OnInteract.performed += OnInteract;
            inputControls.Enable();
        }

        // disable the input controller.
        private void OnDisable()
        {
            inputControls.Player.OnInteract.performed -= OnInteract;
            inputControls.Disable();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(playerTag))
            {
                _playerInRange = true;
                Debug.Log("Player in range!");

                if (objectInteractionUI != null)
                {
                    objectInteractionUI.gameObject.SetActive(true);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(playerTag))
            {
                _playerInRange = false;
                if (objectInteractionUI != null)
                {
                    objectInteractionUI.gameObject.SetActive(false);
                }
            }
        }
        private void OnInteract(InputAction.CallbackContext context)
        {
            if (_playerInRange)
            {
                onInteract?.Invoke();
                if (objectInteractionUI != null)
                {
                    objectInteractionUI.gameObject.SetActive(false);
                }
            }
        }
    }
}
