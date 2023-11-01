using System.Collections.Generic;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    private float count = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckForBalls(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CheckForBalls(collision.gameObject);
    }

    private void CheckForBalls(GameObject obj)
    {
        if (obj.GetComponent<MergeBalls>() != null)
        {
            count += Time.deltaTime;
        }
        if(count >= 10f)
        {
            //Time.timeScale = 0;
            Debug.Log("you lose L + ratio");
        }
    }
}
