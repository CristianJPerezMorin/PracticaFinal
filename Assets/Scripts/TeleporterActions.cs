using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterActions : MonoBehaviour
{
    public GameObject luzTeleporter1, luzTeleporter2;
    public bool canTeleportPlayer = false;

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
                if (canTeleportPlayer)
                {
                    if (SceneManager.GetActiveScene().name.Contains("Active0"))
                    {
                        SceneManager.LoadScene("Puzzle1");
                    }

                    if (SceneManager.GetActiveScene().name.Contains("Puzzle1"))
                    {
                        GameManager.Instance.stopTimer = false;
                        SceneManager.LoadScene("MenuFinal");
                    }
                }
            }
        }
        else
        {
            luzTeleporter1.GetComponent<Light>().enabled = false;
            luzTeleporter2.GetComponent<Light>().enabled = false;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canTeleportPlayer = true;
        }
        else
        {
            canTeleportPlayer = false;
        }
    }
}
