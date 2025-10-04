using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundParallax : MonoBehaviour
{
    private float _startPos;
    private float _length;
    [SerializeField] GameObject _cam;
    [SerializeField] float _parallaxSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movement = _cam.transform.position.x * (1 -_parallaxSpeed);
        float distance = _cam.transform.position.x * _parallaxSpeed;
        
        transform.position = new Vector3(_startPos + distance, transform.position.y, transform.position.z);

        if (movement > _startPos + _length)
        {
            _startPos += _length;
        }
        else if(movement < _startPos - _length)
        {
            _startPos -= _length;
        }
    }
}
