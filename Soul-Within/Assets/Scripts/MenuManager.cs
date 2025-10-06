using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    private PlayerControls inputControls;

    private void Awake()
    {
        inputControls = new PlayerControls();
    }

    // Grabs input player controller
    private void OnEnable()
    {
        inputControls.Player.StartLevelAgain.performed += StartLevelAgain;
        inputControls.Enable();
    }

    // disable the input controller.
    private void OnDisable()
    {
        inputControls.Player.StartLevelAgain.performed -= StartLevelAgain;
        inputControls.Disable();
    }

    private void StartLevelAgain(InputAction.CallbackContext context)
    {
        RestartGame();
    }

    // Load scene again
    public void RestartGame()
    {
        SceneManager.LoadScene("Samantha");
    }
}
