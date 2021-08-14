using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class OvniScript : MonoBehaviour
{

    public Transform[] waypoints;
    private int current;
    public float speed;
    public GameObject bullet;
    public float corrutina;
    public Animator animator;

    private void Start()
    {
        current = 0;
        speed = 5;
        StartCoroutine(dispara());
    }
     

    private void Update()
    {

        
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, waypoints[current].position) < 0.5)
        {
            current++;
            current = current % waypoints.Length;
        }
            
    }

    private IEnumerator dispara()
    {
        while (true)
        {
            print("dispara");
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(corrutina);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.layer);
        if (collision.gameObject.layer == 8)
        {
            animator.SetTrigger("Colision");
            Destroy(gameObject, 1);
        }
    }
}
