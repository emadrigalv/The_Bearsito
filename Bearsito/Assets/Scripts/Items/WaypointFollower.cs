using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;

    [SerializeField] private float speed = 2f;

    private int waypointIndex = 0;


    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoints[waypointIndex].transform.position, transform.position) < .1f)
        {
            waypointIndex++;

            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
        
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime*speed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawLine(waypoints[0].transform.position, waypoints[1].transform.position);
    }

}
