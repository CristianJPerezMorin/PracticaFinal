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
        
    }

    // Update is called once per frame
    void Update()
    {
        time.text += GameManager.Instance.timer;
    }
}
