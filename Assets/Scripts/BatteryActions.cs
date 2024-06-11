using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        transform.Rotate(new Vector3(0, 3, 0) * 50 * Time.deltaTime);

        if (SceneManager.GetActiveScene().name.Contains("Puzzle1"))
        {
            this.gameObject.SetActive(true);
        }

        GameManager.Instance.batteryObtained = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.batteryObtained = true;

            Destroy(gameObject);
        }
    }
}
