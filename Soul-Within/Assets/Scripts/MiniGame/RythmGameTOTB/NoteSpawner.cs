using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Video;


public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> notes = new List<GameObject>();
    private List<GameObject> activeNotes = new List<GameObject>();

    [SerializeField] GameObject _spawnPosition;
    [SerializeField] private float _spawnTime = 2f;
    
    private int _nextNoteList = 0;

    // missed notes 
    private int _missPoint = 0;
    [SerializeField] private int _maxMiss = 3;

    // Verander misschien naar game obejct active and false voor.
    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private GameObject minigameFalse;
    private bool isGameRunning = true;
    private bool isVideoPlaying = false;

    private void Start()
    {
        minigameFalse.gameObject.SetActive(true);
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (isGameRunning)
        {
            if (_missPoint >= _maxMiss)
            {
                Debug.Log("Game OVer rest");
                ResetGame();
                yield break;
            }
            if (_nextNoteList >= notes.Count)
            {
                isGameRunning = false;
                PlayVideo();
                yield break; 
            }
            SpawnNextNote();
            yield return new WaitForSeconds(_spawnTime);
        }
    }

    private void SpawnNextNote()
    {
        if (_nextNoteList >= notes.Count)
        {
            _nextNoteList = 0; 
        }

        GameObject prefab = notes[_nextNoteList];

        GameObject instance = Instantiate(prefab, _spawnPosition.transform.position, Quaternion.identity);
        activeNotes.Add(instance);
        
        Note noteScript = instance.GetComponent<Note>();
        if (noteScript != null)
        {
            noteScript.SetSpawner(this); 
        }

        _nextNoteList++;
    }

    public void AddMissPoint()
    {
        _missPoint = _missPoint + 1;
        Debug.Log("Miss point");
        if(_missPoint >= _maxMiss)
        {
            Debug.Log("game over try again");
            ResetGame();
        }
    }

    private void ResetGame()
    {
        _missPoint = 0;
        _nextNoteList = 0;

        foreach (var note in activeNotes)
        {
            if (note != null)
            {
                Destroy(note);
            }
        }
        activeNotes.Clear();
    }

    // verander dit nog naar game obejct set active shit
    private void PlayVideo()
    {
        videoPlayer.gameObject.SetActive(true);
        minigameFalse.gameObject.SetActive(false);
        //videoPlayer.Play();
    }
}
