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
    private Material Material;

    private float A = 0;

    void Start()
    {
       // rotation = new Vector3( Random.Range(-1,1), Random.Range(-1, 1), Random.Range(-1, 1));
        speed = Random.Range(1,3);
        collisionSource = GetComponent<AudioSource> ();
        Material = GetComponent<Renderer>().material;
        Material.SetColor("_Color", new Color(1, 1, 1, A));

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(1, 0, 0)*speed*Time.deltaTime*20;
        return;
        if (A<=1)
        {
            A += Time.deltaTime * 0.3f;
        }
        Material.SetColor("_Color", new Color(1, 1, 1, A));
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
