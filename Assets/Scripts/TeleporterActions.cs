using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterActions : MonoBehaviour
{
    public GameObject luzTeleporter1, luzTeleporter2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.batteryObtained)
        {
            luzTeleporter1.GetComponent<Light>().enabled = true;
            luzTeleporter2.GetComponent<Light>().enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (SceneManager.GetActiveScene().name.Contains("Active0"))
                {
                    SceneManager.LoadScene("Puzzle1");
                }

                if (SceneManager.GetActiveScene().name.Contains("Puzzle1"))
                {
                    SceneManager.LoadScene("Final");
                }
            }
        }
        else
        {
            luzTeleporter1.GetComponent<Light>().enabled = false;
            luzTeleporter2.GetComponent<Light>().enabled = false;
        }
    }
}
