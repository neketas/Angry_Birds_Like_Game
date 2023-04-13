using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 initialPosition;
    float timeSittingAround;
    bool birdReleased;

    [SerializeField] float forceValue = 100;
    
    
    void Awake()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, initialPosition);
        GetComponent<LineRenderer>().SetPosition(1, transform.position);

        if(birdReleased && GetComponent<Rigidbody2D>().velocity.magnitude < 0.1)
        {
            timeSittingAround += Time.deltaTime;
        }
        if(transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10 || timeSittingAround > 2)
        {
            string currentScemeName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScemeName);
        }
    }
    void OnMouseDown() 
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }
    void OnMouseUp() 
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * forceValue);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        birdReleased = true;     
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Fly");
        GetComponent<LineRenderer>().enabled = false;
    }
    void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Ground"))
        {
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger("Idle");
        }
       
    }
}
