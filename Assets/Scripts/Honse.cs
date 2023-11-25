using System.Collections;
using System.Collections.Generic;
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

    private Vector3 _originalPos;
    // Start is called before the first frame update
    void Start()
    {
        _originalPos = transform.position;
        _firstRotation = Quaternion.Euler(0f, 0f, _rotationOne);
        _secondRotation = Quaternion.Euler(0f, 0f, _rotationTwo);
        StartCoroutine(MoveHonse(_delay));
    }

    private bool _moveHonse = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = _originalPos;
            _moveHonse = true;
        }

        if (_moveHonse)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * _moveSpeed, transform.position.y, transform.position.z);
        }
    }




    private IEnumerator MoveHonse(float waitTime)
    {
        while (true)
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
