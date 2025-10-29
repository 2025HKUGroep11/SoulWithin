using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private RectTransform _hitZoneRect;
    [SerializeField] private float _hitRange = 50f;

    private bool _inHitZone = false;
    private RectTransform _rectTransform;

    private NoteSpawner _spawnerScript;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _spawnerScript = Object.FindFirstObjectByType<NoteSpawner>();
    }

    // Update is called once per frame
    private void Update()
    {
        _rectTransform.anchoredPosition += Vector2.left * _speed * Time.deltaTime; // Move left to right
        float distance = Mathf.Abs(_rectTransform.anchoredPosition.x - _hitZoneRect.anchoredPosition.x);
        _inHitZone = distance < _hitRange;

        if (_inHitZone && Input.GetMouseButtonDown(0))
        {
            Debug.Log("not is hit");
            Destroy(gameObject);
        }
        if (_rectTransform.anchoredPosition.x < _hitZoneRect.anchoredPosition.x - _hitRange)
        {
            _spawnerScript.AddMissPoint();
            Destroy(gameObject);
        }

        // Check for hitzone 
        if(_inHitZone)
        {
            _rectTransform.GetComponent<Image>().color = Color.green;
        }
        else
        {
            _rectTransform.GetComponent<Image>().color = Color.red;
        }
    }

}
