using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 moveDir;


    private void Start()
    {
        moveDir = transform.TransformDirection(Vector3.forward);
    }

    private void Update()
    {

        float step = 10f * Time.deltaTime; // calculate distance to move

        transform.position += moveDir * step;

    }
}
