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
        if (vec.y > 50 && !PauseMenu.GameIsPaused)
        {
            time++;
            if (time > 200)
            {
                int count = (int)Random.Range(3, 5);
                for (int i = 0; i < count; i++)
                {
                    Vector3 target = new Vector3(vec.x - Random.Range(280, 380), vec.y + Random.Range(-170, 170), Random.Range(-220, 220));
                    RockBehavior.speed = Random.Range(0, 3);
                    GameObject newMonster = Instantiate(monster, target, monster.transform.rotation) as GameObject;
                    Destroy(newMonster, 5);
                }

                time = 0;
            }
        }

    }
}
