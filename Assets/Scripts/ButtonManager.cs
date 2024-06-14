using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject panel, startButton, controlButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Active0");
    }

    public void DesactivatePanel()
    {
        startButton.SetActive(true);
        controlButton.SetActive(true);
        panel.SetActive(false);
    }

    public void ActivateControlPanel()
    {
        startButton.SetActive(false);
        controlButton.SetActive(false);
        panel.SetActive(true);
    }
}
