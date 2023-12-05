using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Build;
using UnityEngine;

public class Honse : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    [SerializeField] private float _rotationOne = -45f;
    [SerializeField] private float _rotationTwo = 45f;

    [SerializeField] private float _moveSpeed = 10f;

    private bool _flip = true;

    private Quaternion _firstRotation;
    private Quaternion _secondRotation;

    [HideInInspector] public Vector3 _originalPos;
    [HideInInspector] public bool _moveHonse = false;

    [SerializeField] private SpawnBall _spawnBall;


    [SerializeField] private Transform _honseWaitPos;
    
    // Start is called before the first frame update
    void Start()
    {
        _originalPos = transform.position;
        _firstRotation = Quaternion.Euler(0f, 0f, _rotationOne);
        _secondRotation = Quaternion.Euler(0f, 0f, _rotationTwo);
        StartCoroutine(RotateHonse(_delay));
    }




    private void Update()
    {
        Debug.Log(_spawnBall._ballCount);
        if(_spawnBall._ballCount % _spawnBall._blendWaitCount == 0 && _spawnBall._ballCount != 0 && _honseIsVisible)
        {
            _moveHonse = true;
        }
        else
        {
            _moveHonse = false;
        }

        if (_moveHonse)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * _moveSpeed, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _originalPos, Time.deltaTime * _moveSpeed);
        }

        if (Vector2.Distance(transform.position, _originalPos) < 0.01 &&
            _spawnBall._ballCount % _spawnBall._blendWaitCount != 0)
        {
            _honseIsVisible = true;
        }
        
        
        
    }

    private bool _honseIsVisible = true;
    void OnBecameInvisible()
    {
        _honseIsVisible = false;
        _moveHonse = false;
        transform.position = _honseWaitPos.position;
    }


    private bool _playWalkAnim = true;

    private IEnumerator RotateHonse(float waitTime)
    {
        while (_playWalkAnim)
        {
            _flip = !_flip;
            if (_flip)
            {
                transform.rotation = _firstRotation;
            }
            else
            {
                transform.rotation = _secondRotation;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
