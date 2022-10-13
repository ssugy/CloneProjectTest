using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_30_Player : MonoBehaviour
{
    public LineRenderer lineRenderer;
    Vector3 end;
    Vector3 targetPosition;
    float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.SetPosition(0, transform.position);
        end = transform.position;
        moveSpeed = 10f;
        FindTargetPosition();
    }
    void FindTargetPosition()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position, transform.forward, out hitInfo, Mathf.Infinity))
        {
            targetPosition = hitInfo.point;
        }
    }
    // Update is called once per frame
    void Update()
    {
        FindTargetPosition();
        end = Vector3.MoveTowards(end, targetPosition, Time.deltaTime * moveSpeed);
        lineRenderer.SetPosition(1, end);
    }
}
