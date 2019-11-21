using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    public Transform target;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 120)
        {
            transform.LookAt(target);
            transform.rotation.SetLookRotation(new Vector3(0, 0, 0));
            Debug.Log("This happens.");
        }
        counter++;
        Debug.Log(counter);
    }
}
