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
        Transform pos = rig.centerEyeAnchor;
        Vector3 vec = pos.position;
        for (int i = 0; i < 10; i++)
        {
            Vector3 target = new Vector3(vec.x + Random.Range(-1000, 1000), vec.y + Random.Range(-180, 200), vec.z + Random.Range(-1000, 1000));
            GameObject newFog = Instantiate(fog, target, fog.transform.rotation) as GameObject;
            //float scaleRate = Random.Range(-0.8f, 1.5f);
            //newFog.transform.localScale += new Vector3(scaleRate, scaleRate, scaleRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Transform pos = rig.centerEyeAnchor;
        //Vector3 vec = pos.position;
        //if (vec.y > 400 && !Menu.GameIsPaused)
        //{
        //    time++;
        //    if (time > 200)
        //    {
        //        //Vector3 target = new Vector3(vec.x - Random.Range(500, 600), vec.y + Random.Range(-80, 30), vec.z + Random.Range(-220, 220));
        //        Vector3 target = new Vector3(vec.x, vec.y + Random.Range(-170, 170), vec.z);
        //        target += pos.forward * Random.Range(400, 600);
        //        target += pos.right * Random.Range(-220, 220);
        //        GameObject newFog = Instantiate(fog, target, fog.transform.rotation) as GameObject;
        //        float scaleRate = Random.Range(-0.8f, 1.5f);
        //        newFog.transform.localScale += new Vector3(scaleRate, scaleRate, scaleRate);
        //        Destroy(newFog, 10);
        //        time = 0;
        //    }
        //}

    }
}
