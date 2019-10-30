using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public static float speed;
    Collider m_ObjectCollider;
    void Start()
    {
        m_ObjectCollider = GetComponent<Collider>();
        m_ObjectCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDING");
        Debug.Log(other.name);
        if(other.name == "Player")
        {
            Debug.Log("You die.");
            //Time.timeScale = 0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        
    }
}
