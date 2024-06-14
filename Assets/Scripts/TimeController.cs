using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public TMP_Text time;

    // Start is called before the first frame update
    void Start()
    {
        float min = Mathf.FloorToInt(GameManager.Instance.timer / 60F);
        float sec = Mathf.FloorToInt(GameManager.Instance.timer - min * 60);

        time.text += min + " minutos " + sec + " segundos.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
