using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.up * Time.deltaTime * 100);
        rb.velocity = -transform.up * 2;

    }
}
