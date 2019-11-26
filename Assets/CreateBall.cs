using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour
{
    public GameObject Ball;
    
    public Transform Target;

    public Transform Player;

    private float Timer;

  
    void Start()
    {
        
    }

    
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >=0.1f)
        {
            Timer = 0;
            CreateABall();
        }
    }

    private void CreateABall()
    {
        GameObject go = Instantiate(Ball);
        go.transform.position = (Target.position + Player.position) / 2 + new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
        go.SetActive(true);
    }

   
}
