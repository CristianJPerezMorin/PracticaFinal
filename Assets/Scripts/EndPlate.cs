using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPlate : MonoBehaviour
{
    public int platesActive;

    public static EndPlate Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself

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
        platesActive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Puzzle0")
        {
            if (platesActive == 17)
            {
                PuzzleManager.Instance.isPuzzleFinished = true;
                SceneManager.LoadScene(GameManager.Instance.gameSceneActive);
            }
        }
    }
}
