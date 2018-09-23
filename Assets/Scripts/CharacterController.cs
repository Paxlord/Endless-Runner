using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour {

    Rigidbody2D rb;

    Vector3 originalScale;
    Vector3 downScale;

    bool hasDied;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody2D>();

        hasDied = false;

        originalScale = this.transform.localScale;
        downScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y / 2, this.transform.localScale.z);
    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit2D[] hits = new RaycastHit2D[10];

        
        if (Input.GetButton("Down"))
        {
            this.transform.localScale = downScale;
        }
        else
        {
            this.transform.localScale = originalScale;

            if (Input.GetButtonDown("Jump") && rb.Cast(Vector2.down, hits, 0.1f) > 0)
            {
                rb.velocity = new Vector2(0, 30f);
            }

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasDied = true;
    }

    public bool isDead()
    {
        return this.hasDied;
    }

}
