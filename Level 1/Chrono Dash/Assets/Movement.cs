
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public GameObject gameOverText, restartButton;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
           gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 20f), ForceMode2D.Impulse);
               
        }
        
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}