using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    public AudioSource collisionSource;

    public Transform Player;



    private void Start()
    {
       
    }

    private void Update()
    {
        transform.LookAt(Player);
        transform.Translate(Vector3.forward * Time.deltaTime * 200, Space.Self);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDING");
        Debug.Log(other.name);
        if (other.name == "Player")
        {
            collisionSource.Play();
            Debug.Log("You die.");
            Menu.isDead = true;
        }

    }
}
