using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class monster_script : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent nma;
    public Vector3 center;
    private Vector3 nextPosition;
    public float radius;
    private float height;
    private float x;
    private float z;
    private int status;
    private float speed;
    AnimationClip[] clips;
    Animation ani;
    // Start is called before the first frame update
    void Start()
    {
        nma = gameObject.GetComponent<NavMeshAgent>();
        speed = nma.speed;
        height = transform.position.y;
        radius = 10f;
        center = transform.position;
        x = center.x + Random.Range(-radius, radius);
        z = center.z + Random.Range(-radius, radius);
        nextPosition = new Vector3(x, height, z);
        nma.nextPosition = nextPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (status == 0)
        {
            nma.speed = speed;
            if (nma.remainingDistance <= 0.1f)
            {
                x = center.x + Random.Range(-radius, radius);
                z = center.z + Random.Range(-radius, radius);
                nextPosition = new Vector3(x, height, z);
                nma.nextPosition = nextPosition;
            }
        }
        else if (status == 1)
        {
            speed = nma.speed;
            nma.speed = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "3rd Person Controller")
            status = 1;
        Debug.Log("COLLIDING WITH " + other.gameObject.name);
    }
    public void OnTriggerExit(Collider other)
    {
        status = 0;
    }
}
