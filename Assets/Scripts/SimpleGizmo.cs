using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGizmo : MonoBehaviour
{
    [SerializeField] private float _gizmoRadius = 1f;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, _gizmoRadius);
    }
}
