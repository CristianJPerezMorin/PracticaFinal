using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public bool inPuzzleMode;
    public bool isPuzzleFailed;
    public bool isPuzzleFinished;

    public static PuzzleManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inPuzzleMode = false;
        isPuzzleFailed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPuzzleFailed)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        if (isPuzzleFinished)
        {
            GameManager.Instance.isPuzzleCompleted = true;
        }
    }
}
