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
        time.text += Math.Round(GameManager.Instance.timer, 2) + " segundos.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
