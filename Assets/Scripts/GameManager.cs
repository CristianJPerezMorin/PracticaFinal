using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPuzzleCompleted;
    public bool noMorePuzzles;
    public bool batteryObtained;
    public bool stopTimer;

    public string gameScenePuzzle;
    public string gameSceneActive;
    public string levelName;

    Material lastMaterial;

    public float timer = 0;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Puzzle0"))
        {
            PuzzleManager.Instance.inPuzzleMode = true;
        }

        if (isPuzzleCompleted)
        {
            isPuzzleCompleted = false;
            noMorePuzzles = true;
            SceneManager.LoadScene(gameSceneActive);
        }

        if (SceneManager.GetActiveScene().name.Contains("Active"))
        {
            gameSceneActive = SceneManager.GetActiveScene().name;
            gameScenePuzzle = "Puzzle" + gameSceneActive.Substring(gameSceneActive.Length - 1);
        }
        if (SceneManager.GetActiveScene().name.Contains("Puzzle"))
        {
            gameScenePuzzle = SceneManager.GetActiveScene().name;
            gameSceneActive = "Active" + gameScenePuzzle.Substring(gameScenePuzzle.Length - 1);
        }

        if (!stopTimer)
        {
            timer += Time.deltaTime;
        }
    }
}
