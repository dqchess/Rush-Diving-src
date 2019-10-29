using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diver : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 originalAngle = new Vector3(-1, 0, 0);
    //Vector3 originalAngle =   Vector3.forward;
    //public Transform leftHand;
    //public Transform rightHand;

    //GameObject root = GameObject.Find("OVRCameraRig");

    void Start()
    {
        Debug.Log("****************************");
        Debug.Log(transform.Find("TrackingSpace").transform.Find("CenterEyeAnchor").rotation);
        Debug.Log("****************************");
        Debug.Log(transform.forward);
        Debug.Log(transform.up);
        Debug.Log(transform.right);
    }
    //Transform leftHand = GameObject.Find("LeftHandAnchor").transform;
    //Transform rightHand = GameObject.Find("RightHandAnchor").transform;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y>0){
            transform.position -= Time.deltaTime * transform.up *10;
            // transform.position += Time.deltaTime * transform.forward *100;
            transform.position += Time.deltaTime * originalAngle *100;
            // transform.position += Time.deltaTime * transform.rotation.x *10;
        }

        float turningSpeed = 0.2f;

        if (OVRInput.Get(OVRInput.Button.One))
        //if (transform.Find("TrackingSpace").transform.Find("LeftHandAnchor").position.y > transform.Find("TrackingSpace").transform.Find("RightHandAnchorr").position.y)
        {
            Debug.Log("Turning Right:");
            Debug.Log(transform.Find("TrackingSpace").transform.Find("LeftHandAnchor").position.y);
            Debug.Log(transform.Find("TrackingSpace").transform.Find("RightHandAnchor").position.y);
            // Debug.Log(transform.Find("TrackingSpace").transform.Find("CenterEyeAnchor").rotation);
            // transform.Rotate(new Vector3(0, 0.1f, 0));
            transform.rotation *= Quaternion.AngleAxis(turningSpeed, Vector3.up);
            originalAngle = Quaternion.AngleAxis(turningSpeed, new Vector3(0, 1, 0)) * originalAngle;
        }

        if (OVRInput.Get(OVRInput.Button.Three))
            //if (transform.Find("TrackingSpace").transform.Find("LeftHandAnchor").position.y < transform.Find("TrackingSpace").transform.Find("RightHandAnchorr").position.y)
        {
            Debug.Log("Turning Left:");
            //Debug.Log(leftHand.position.y);
            //Debug.Log(rightHand.position.y);
            // Debug.Log(transform.Find("TrackingSpace").transform.Find("CenterEyeAnchor").rotation);
            // transform.Rotate(new Vector3(0,-0.1f,0));
            transform.rotation *= Quaternion.AngleAxis(-turningSpeed, Vector3.up);
            originalAngle = Quaternion.AngleAxis(-turningSpeed, new Vector3(0,1,0))*originalAngle;
        }

    }
}
