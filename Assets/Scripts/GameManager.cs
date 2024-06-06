using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPuzzleCompleted;
    public bool noMorePuzzles;

    public string gameScenePuzzle;
    public string gameSceneActive;

    Material lastMaterial;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        DontDestroyOnLoad(this.gameObject);

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
        if(SceneManager.GetActiveScene().name.Contains("Active"))
        {
            gameSceneActive = SceneManager.GetActiveScene().name;
            gameScenePuzzle = "Puzzle" + gameSceneActive.Substring(gameSceneActive.Length - 1);
        }
        else
        {
            gameScenePuzzle = SceneManager.GetActiveScene().name;
            gameSceneActive = "Active" + gameScenePuzzle.Substring(gameScenePuzzle.Length - 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Puzzle"))
        {
            PuzzleManager.Instance.inPuzzleMode = true;
        }

        if (isPuzzleCompleted)
        {
            isPuzzleCompleted = false;
            noMorePuzzles = true;
            SceneManager.LoadScene(gameSceneActive);
        }
    }


}
