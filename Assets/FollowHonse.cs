using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHonse : MonoBehaviour
{
    [SerializeField] private Transform _honse;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _honse.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _honse.position + _offset;
    }
}
