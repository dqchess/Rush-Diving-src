using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverControl : MonoBehaviour
{
    //private CharacterController controller;
    // Start is called before the first frame update
    public GameObject leftHand;
    public GameObject rightHand;

    Vector3 originalAngle = new Vector3(-1, 0, 0);
    private float baseSpeed = 10.0f;
    private float rotSpeedX = 20.0f;
    private float leanCount = 0f;
    public float maxLean = 200f;

    public static Vector3 moveVector;

    private float lastFrameLeftHeight;
    private float lastFrameRightHeight;

    void Start()
    {
        //controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = transform.forward * baseSpeed;

        Vector3 inputs = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        float heightDiff = leftHand.transform.position.y - rightHand.transform.position.y;
        float stableTh = 0.1f;
        float strength = 6f;

        if (heightDiff > 0)
        {
            heightDiff /= 1.5f;
        }

        if (heightDiff <= stableTh && heightDiff >= -stableTh)
        {
            inputs.x = 0;
        }
        else if (heightDiff > 0)
        {
            inputs.x = (heightDiff - stableTh) * strength;
        }
        else
        {
            inputs.x = (heightDiff + stableTh) * strength;
        }

        if (!Menu.GameIsPaused)
        {
            Debug.Log(inputs.x);
        }


        Vector3 yaw = inputs.x * transform.right * rotSpeedX * Time.deltaTime;

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger)>0 && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger)>0)
        {
            if(leftHand.transform.position.y > lastFrameLeftHeight && rightHand.transform.position.y > lastFrameRightHeight)
            {
                inputs.y = 1f;
            }
            if(leftHand.transform.position.y < lastFrameLeftHeight && rightHand.transform.position.y < lastFrameRightHeight)
            {
                inputs.y = -1f;
            }

            yaw += inputs.y * transform.up * rotSpeedX * Time.deltaTime;
        }


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

        transform.Rotate(new Vector3(0, 0, -leanCount * 0.15f));
        //Debug.Log(transform.rotation.y);
        //transform.rotation = Quaternion.Euler(0, transform.rotation.y*360, -leanCount * 0.1f);

        lastFrameLeftHeight = leftHand.transform.position.y;
        lastFrameRightHeight = rightHand.transform.position.y;
    }
}
