using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diver : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 originalAngel = new Vector3(0.7f,0,0.7f);
    void Start()
    {
        Debug.Log("****************************");
        Debug.Log(transform.Find("TrackingSpace").transform.Find("CenterEyeAnchor").rotation);
        Debug.Log("****************************");
        Debug.Log(transform.forward);
        Debug.Log(transform.up);
        Debug.Log(transform.right);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y>0){
            transform.position -= Time.deltaTime * transform.up *10;
            // transform.position += Time.deltaTime * transform.forward *100;
            transform.position += Time.deltaTime * originalAngel *100;
            
            // transform.position += Time.deltaTime * transform.rotation.x *10;
        }

        if(OVRInput.Get(OVRInput.Button.One)){
            Debug.Log("Button One is being pressed.");
            // Debug.Log(transform.Find("TrackingSpace").transform.Find("CenterEyeAnchor").rotation);
            transform.Rotate(new Vector3(0,0.1f,0));
            originalAngel = Quaternion.AngleAxis(0.1f,new Vector3(0,1,0))*originalAngel;
        }

        if(OVRInput.Get(OVRInput.Button.Three)){
            Debug.Log("Button One is being pressed.");
            // Debug.Log(transform.Find("TrackingSpace").transform.Find("CenterEyeAnchor").rotation);
            transform.Rotate(new Vector3(0,-0.1f,0));
            originalAngel = Quaternion.AngleAxis(-0.1f,new Vector3(0,1,0))*originalAngel;
        }

    }
}
