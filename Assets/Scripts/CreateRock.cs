using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRock : MonoBehaviour
{
    public GameObject rock;
    public OVRCameraRig rig;
    public int time;
    Queue<GameObject> q;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        //rock.AddComponent<RockBehavior>();
        //rock.AddComponent<SphereCollider>();
        //rock.AddComponent<Rigidbody>();
        SphereCollider sc = rock.GetComponent<SphereCollider>();
        sc.isTrigger = true;
        sc.radius = 12;
        sc.center = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Transform pos = rig.centerEyeAnchor;
        Vector3 vec = pos.position;
        if (vec.y > 50 & !PauseMenu.GameIsPaused)
        {
            //Vector3 target = new Vector3(vec.x - 50, vec.y, 0);
            //print(pos.position);
            time++;
            if (time > 200)
            {
                int count = (int)Random.Range(5, 15);
                for (int i = 0; i < count; i++)
                {
                    Vector3 target = new Vector3(vec.x - Random.Range(280, 380), vec.y + Random.Range(-170, 170), Random.Range(-220, 220));
                    //rock.AddComponent<RockBehavior>();
                    //rock.AddComponent<SphereCollider>();
                    //SphereCollider sc = rock.GetComponent<SphereCollider>();
                    //sc.radius = 12;
                    //sc.isTrigger = true;
                    RockBehavior.speed = Random.Range(0, 3);
                    GameObject go = Instantiate(rock, target, Quaternion.identity) as GameObject;
                    Destroy(go, 4);
                    //q.Enqueue(go);
                }

                time = 0;
            }
        }
        
    }

}
