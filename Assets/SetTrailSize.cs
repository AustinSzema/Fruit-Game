using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrailSize : MonoBehaviour
{
    [SerializeField] private TrailRenderer _trailRenderer;

    private void Update()
    {
        _trailRenderer.startWidth = transform.localScale.x / 2f;
    }
}
