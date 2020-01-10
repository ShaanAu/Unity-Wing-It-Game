using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public float upForce = 0.2f;
    public bool isDead = false;

    private Rigidbody2D rb2d;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, 100f));
            anim.SetTrigger("Flap");
        }
    }

    void OnCollisionEnter2D()
    {
       // GameControls.health -= 1;
      // if (GameControls.health == 0)
        //{
            isDead = true;
            rb2d.velocity = Vector2.zero;
            anim.SetTrigger("Die");
            GameControls.Instance.Death();
      //  }
       // isDead = true;
        //rb2d.velocity = Vector2.zero;
        //anim.SetTrigger("Die");
       // GameControls.Instance.Death();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Orb"))
        {
            other.gameObject.SetActive(false);
        }
    }

}
