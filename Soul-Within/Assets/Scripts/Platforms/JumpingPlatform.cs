using UnityEngine;

public class JumpingPlatform : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
