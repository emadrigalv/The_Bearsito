using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] public Transform door1, door2;

    [SerializeField] public Transform openedPosition1, openedPosition2;

    public Vector3 closedPosition1, closedPosition2;

    [SerializeField] private float speed = 2f;

    [SerializeField] public bool isDoorOpen;

    [SerializeField] public bool isDoorClose;

    public void Awake()
    {
        closedPosition1 = door1.position;

        if(door2 != null)
        {
            closedPosition2 = door2.position;
        }
    }

    public void OpenDoor()
    {
         StopAllCoroutines();
         StartCoroutine(OpenDoorCoroutine());
    }

    public void CloseDoor()
    {
        StopAllCoroutines();
        StartCoroutine(CloseDoorCoroutine());
    }

    private IEnumerator OpenDoorCoroutine()
    {
        while (Vector2.Distance(door1.position, openedPosition1.position) > 0.1f) 
        {
            
            door1.position = Vector3.MoveTowards(door1.position, openedPosition1.position, Time.deltaTime * speed);

            if (door2 != null)
            {
                door2.position = Vector3.MoveTowards(door2.position, openedPosition2.position, Time.deltaTime * speed);
            }

            yield return null;
        }
    }

    private IEnumerator CloseDoorCoroutine()
    {
        while(Vector2.Distance(door1.position, closedPosition1) > 0.1f)
        {
            door1.position = Vector3.MoveTowards(door1.position, closedPosition1, Time.deltaTime * speed);

            if (door2 != null)
            {
                door2.position = Vector3.MoveTowards(door2.position, closedPosition2, Time.deltaTime * speed);
            }

            yield return null;
        }

    }
}
