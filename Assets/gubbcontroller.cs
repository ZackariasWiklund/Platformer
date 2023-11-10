using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gubbcontroller : MonoBehaviour
{

    [SerializeField]
    float Speed = 10;

    [SerializeField]
    float jumpForce = 100;

    [SerializeField]
    Transform feet;

    [SerializeField]
    LayerMask groundLayer;
    Rigidbody2D rigidbody;

    [SerializeField]
    float groundRadius = 0.2f;


    bool hasReleasedJumpButton = true;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        float moveX = Input.GetAxisRaw("Horizontal");

        Vector2 movementX = new Vector2(moveX, 0);

        transform.Translate(movementX * Speed * Time.deltaTime);

        bool isGrounded = Physics2D.OverlapCircle(feet.position, groundRadius, groundLayer);

        Debug.Log(isGrounded);


        if (Input.GetAxisRaw("Jump") > 0 && hasReleasedJumpButton == true && isGrounded)
        {
            
            rigidbody.AddForce(Vector2.up * jumpForce);
            hasReleasedJumpButton = false;
        }

        if (Input.GetAxisRaw("Jump") == 0)
        {
            hasReleasedJumpButton = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Drop"){
            SceneManager.LoadScene(1);
        }
        if(other.gameObject.tag == "Win"){
            SceneManager.LoadScene(2);
        }
    }

    private void OnDrawGizmos()
    {
        if (feet)
        {
            Gizmos.DrawWireSphere(feet.position, groundRadius);
        }
    } 

    
    }


