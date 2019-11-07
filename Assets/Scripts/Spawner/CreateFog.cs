using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFog : MonoBehaviour
{
    public GameObject fog;
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
        if (vec.y > 50 && !Menu.GameIsPaused)
        {
            time++;
            if (time > 200)
            {
                Vector3 target = new Vector3(vec.x - Random.Range(500, 600), vec.y + Random.Range(-80, 30), vec.z + Random.Range(-220, 220));
                GameObject newFog = Instantiate(fog, target, fog.transform.rotation) as GameObject;
                float scaleRate = Random.Range(-0.8f, 1.5f);
                newFog.transform.localScale += new Vector3(scaleRate, scaleRate, scaleRate);
                Destroy(newFog, 10);
                time = 0;
            }
        }

    }
}
