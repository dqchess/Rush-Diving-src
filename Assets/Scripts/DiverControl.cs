using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverControl : MonoBehaviour
{
    //private CharacterController controller;
    // Start is called before the first frame update
    Vector3 originalAngle = new Vector3(-1, 0, 0);
    private float baseSpeed = 100.0f;
    private float rotSpeedX = 20.0f;

    private float leanCount = 0f;
    private float maxLean = 200f;

    void Start()
    {
        //controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = transform.forward * baseSpeed;

        Vector3 inputs = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        Vector3 yaw = inputs.x * transform.right * rotSpeedX * Time.deltaTime;
        Vector3 dir = yaw;

        moveVector += dir;
        transform.rotation = Quaternion.LookRotation(moveVector);

        transform.position += moveVector * Time.deltaTime;
        //controller.Move(moveVector * Time.deltaTime);

        if (inputs.x > 0)// turn right
        {
            if (leanCount <= maxLean)
            {
                leanCount += 1;
            }
        }
        else if (inputs.x < 0)
        {
            if (leanCount >= -maxLean)
            {
                leanCount -= 1;
            }
        }
        else
        {
            if (leanCount > 0)
            {
                leanCount -= 1;
            }
            else
            {
                leanCount += 1;
            }

        }

        transform.Rotate(new Vector3(0, 0, -leanCount * 0.1f));
    }
}
