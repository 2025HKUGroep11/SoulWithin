using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform hitZone;
    [SerializeField] private float hitRange = 0.5f;

    private NoteSpawner spawner;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        float distance = Vector2.Distance(transform.position, hitZone.position);

        if (distance < hitRange)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("HIT!");
                Destroy(gameObject);
            }
        }
        else
        {
            
            if (transform.position.x < hitZone.position.x - hitRange)
            {
                Debug.Log("Missed!");
                spawner.AddMissPoint();
                Destroy(gameObject);
                
            }
        }
    }

    public void SetSpawner(NoteSpawner spawnerScript)
    {
        spawner = spawnerScript;
    }
}
