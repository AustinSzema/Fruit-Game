using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EatFruit : MonoBehaviour
{
    [SerializeField] private GameObject _eatParticlesPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MergeBalls>() != null)
        {
            Instantiate(_eatParticlesPrefab, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

        }
    }
}
