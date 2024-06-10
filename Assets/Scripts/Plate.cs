using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plate : MonoBehaviour
{
    private bool activePlate = false;
    public int countTouch = 0;

    Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = new Material(Shader.Find("Standard"));
        material.color = new Color(0, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(activePlate)
        {
            gameObject.GetComponent<Renderer>().material = material;
        }

        if(countTouch == 2)
        {
            PuzzleManager.Instance.isPuzzleFailed = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(countTouch == 0)
            {
                EndPlate.Instance.platesActive++;
            }

            activePlate = true;
            countTouch++;
        }
    }
}
