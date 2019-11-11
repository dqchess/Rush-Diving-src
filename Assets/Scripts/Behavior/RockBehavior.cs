using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Vector3 rotation;
    public AudioSource collisionSource;

    void Start()
    {
        rotation = new Vector3( Random.Range(-1,1), Random.Range(-1, 1), Random.Range(-1, 1));
        speed = Random.Range(1,3);
        collisionSource = GetComponent<AudioSource> ();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDING");
        Debug.Log(other.name);
        if(other.name == "Player")
        {
            collisionSource.Play();
            Debug.Log("You die.");
            Menu.isDead = true;
        }
        
    }
}
