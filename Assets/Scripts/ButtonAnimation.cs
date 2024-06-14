using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(this.gameObject, new Vector3(0.7f, 0.7f, 0.7f), 2f).setDelay(.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(this.gameObject, new Vector3(0.5f, 0.5f, 0.5f), 2f).setDelay(1.7f).setEase(LeanTweenType.easeInOutCubic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
