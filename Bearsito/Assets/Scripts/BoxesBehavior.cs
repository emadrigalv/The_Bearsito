using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesBehavior : MonoBehaviour, IReloadable
{
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void ReloadObject()
    {
        transform.position = initialPosition;
    }
}
