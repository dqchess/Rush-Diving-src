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
        if (vec.y > 100 & !Menu.GameIsPaused)
        {
            //Vector3 target = new Vector3(vec.x - 50, vec.y, 0);
            //print(pos.position);
            time++;
            if (time > 10)
            {
                
                    //Vector3 target = new Vector3(vec.x + pos.forward.x * Random.Range(400, 600), vec.y +  Random.Range(-170, 170), vec.z + pos.forward.x * Random.Range(-220, 220));
                    Vector3 target = new Vector3(vec.x, vec.y+Random.Range(-170, 170), vec.z);
                    target += pos.forward * Random.Range(600, 1000);
                    target += pos.right * Random.Range(-500, 500);
                    GameObject go = Instantiate(rock, target, Quaternion.Euler(new Vector3(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360)))) as GameObject;
                    go.transform.localScale += new Vector3(Random.Range(-0.5f, 2f), Random.Range(-0.5f, 2f), Random.Range(-0.5f, 2f));
                    Destroy(go, 12);
                

                time = 0;
            }
        }
        
    }

}
