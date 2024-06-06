using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plate : MonoBehaviour
{
    private bool activePlate = false;

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
            Debug.Log("Hola");
            gameObject.GetComponent<Renderer>().material = material;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hola2");
            activePlate = true;
        }
    }
}
