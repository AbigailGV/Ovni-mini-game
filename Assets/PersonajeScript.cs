using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeScript : MonoBehaviour
{

    public float speed;
    public Transform pivotito;
    public GameObject bala;
    public GameObject dibujito;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        animator = dibujito.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      float caminar = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * speed * Time.deltaTime * caminar, Space.Self);

        //apuntar a pantalla y obtener coordenadas
        Vector2 posicion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //coversiones para que el personaje pudiera apuntar hacia donde está el mouse
        //en 3D es "lookAt()"
        posicion = posicion - (Vector2)pivotito.position;
        posicion = posicion.normalized;
        pivotito.transform.up = posicion;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bala, pivotito.position, pivotito.rotation);
        }
        if(caminar > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            animator.SetBool("Caminar", true);
        }
        else if (caminar < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            animator.SetBool("Caminar", true);
        }
        else
        {
            animator.SetBool("Caminar", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            animator.SetTrigger("Hit");
        }
    }
    
}
