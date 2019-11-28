using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public AudioSource collisionSource;

    public Transform Player;

    public Vector3 targetPos;


    private void Start()
    {

        float accuracy = Random.Range(0f, 100f);

        if ( accuracy < 30 )
        {
            targetPos = Player.position;

            Debug.Log("AIMING PLAYER");
        }
        else
        {
            targetPos = Player.position + new Vector3(Random.Range(-40f, 40f), 0, Random.Range(-40f, 40f));
        }


    }

    private void Update()
    {
        //transform.LookAt(targetPos);


        //transform.Translate(Vector3.forward * Time.deltaTime * 700, Space.Self);

        float step = 700f * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);


    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDING");
        Debug.Log(other.name);
        if (other.name == "Player")
        {

            AudioSource audio = other.gameObject.GetComponent(typeof(AudioSource)) as AudioSource;

            Debug.Log("You die.");
            Menu.isDead = true;
        }

    }

}
