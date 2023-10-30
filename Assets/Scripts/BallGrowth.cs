using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallGrowth : MonoBehaviour
{
    // grows balls to their normal size
    private Vector3 _originalSize;
    private Vector3 _shrunkenSize;

    private BallGrowth _ballGrowth;

    private void Start()
    {
        _originalSize = transform.localScale;
        _shrunkenSize = _originalSize * 0.5f;
        transform.localScale = _shrunkenSize;
        _ballGrowth = this;
    }

    private void Update()
    {
        transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);

        Debug.Log(transform.localScale + "      " + _originalSize);

        if (Vector3.Distance(transform.localScale, _originalSize) <= 0.01f)
        {
            Debug.Log("disable");
            transform.localScale = _originalSize;
            _ballGrowth.enabled = false;
        }
    }
}
