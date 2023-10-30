using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class MergeBalls : MonoBehaviour
{
    public int value = 1;

    [SerializeField] private GameObjectArrayVariable _objects;

    private GameObject[] _balls;

    [SerializeField] private GameObject _mergeParticlesPrefab;

    private void Start()
    {
        _balls = _objects.objects;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Merge(collision.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Merge(collision.gameObject);
    }

    private void Update()
    {
        if(FindObjectsOfType<MergeBalls>().Count() > 10)
        {
            //EditorApplication.isPlaying = false;
        }
    }


    private void Merge(GameObject obj)
    {
        MergeBalls merge = obj.GetComponent<MergeBalls>();
        if(merge != null && merge.value == value)
        {
            Vector3 mergePoint = (merge.transform.position + transform.position) / 2f;
                        
            int ballIndex = value++;
            
            if(ballIndex > _balls.Length-1)
            {
                ballIndex = 0;
            }

            Instantiate(_balls[ballIndex], mergePoint, Quaternion.identity);
            Instantiate(_mergeParticlesPrefab, mergePoint, Quaternion.identity);

            Destroy(gameObject);
            Destroy(obj.gameObject);
        }
    }
}