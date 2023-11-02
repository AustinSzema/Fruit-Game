using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honse : MonoBehaviour
{
    [SerializeField] private float _delay = 2f;

    [SerializeField] private float _rotationOne = -45f;
    [SerializeField] private float _rotationTwo = 45f;

    private bool _flip = true;

    private Quaternion _firstRotation;
    private Quaternion _secondRotation;

    // Start is called before the first frame update
    void Start()
    {
        _firstRotation = Quaternion.Euler(0f, 0f, _rotationOne);
        _secondRotation = Quaternion.Euler(0f, 0f, _rotationTwo);
        StartCoroutine(MoveHonse(_delay));
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
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
