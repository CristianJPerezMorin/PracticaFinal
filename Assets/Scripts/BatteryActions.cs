using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryActions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.noMorePuzzles)
        {
            this.gameObject.SetActive(true);
        }

        transform.Rotate(new Vector3(0, 3, 0) * 50 * Time.deltaTime);
    }
}
