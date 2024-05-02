using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPuzzleCompleted;

    public string gameScenePuzzle;
    public string gameSceneActive;


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
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameScenePuzzle = "Puzzle" + Mathf.Abs(SceneManager.sceneCount / 2);
        gameSceneActive = "Active" + Mathf.Abs(SceneManager.sceneCount / 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
