using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateControl : MonoBehaviour
{
    bool isPlateActivated;

    // Start is called before the first frame update
    void Start()
    {
        isPlateActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (!isPlateActivated)
            {
                isPlateActivated = true;
            }
            else
            {
                PuzzleManager.Instance.isPuzzleFailed = true;
            }
        }
    }
}
