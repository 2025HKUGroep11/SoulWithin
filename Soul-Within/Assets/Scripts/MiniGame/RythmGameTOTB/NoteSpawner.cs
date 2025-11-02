using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] GameObject _notePrefab;
    [SerializeField] GameObject _spawnerPlace;
    [SerializeField] private float _spawnTime = 2f;
    private float _timer;

    // missed notes 
    private int _missPoint = 0;
    [SerializeField] private int _maxMiss = 3;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if ( _timer >= _spawnTime)
        {
            _timer = 0;
            SpawnNote();
        }
    }

    private void SpawnNote()
    {
        Vector2 spawnPost = _spawnerPlace.transform.position;
        Instantiate(_notePrefab, spawnPost, Quaternion.identity);
    }

    public void AddMissPoint()
    {
        _missPoint = _missPoint + 1;
        Debug.Log("Miss point");
        if(_missPoint >= _maxMiss)
        {
            Debug.Log("game over try again");
        }
    }
}
