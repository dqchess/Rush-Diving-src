using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    public GameObject monster;
    public OVRCameraRig rig;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Transform pos = rig.centerEyeAnchor;
        Vector3 vec = pos.position;
        if (vec.y > 100 && !Menu.GameIsPaused)
        {
            time++;
            if (time > 200)
            {
                int count = (int)Random.Range(1, 3);
                for (int i = 0; i < count; i++)
                {
                    //Vector3 target = new Vector3(vec.x - Random.Range(400, 500), vec.y + Random.Range(-170, 170), vec.z + Random.Range(-220, 220));
                    Vector3 target = new Vector3(vec.x, vec.y + Random.Range(-170, 170), vec.z);
                    target += pos.forward * Random.Range(400, 600);
                    target += pos.right * Random.Range(-220, 220);
                    GameObject newMonster = Instantiate(monster, target, monster.transform.rotation) as GameObject;
                    Destroy(newMonster, 7);
                }

                time = 0;
            }
        }

    }
}
