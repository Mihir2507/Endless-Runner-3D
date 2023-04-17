using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{

    bool alive = true;

    public float speed = 5; // or[SerializeField]
    public float speedIncreaser = 0.1f;
    [SerializeField] Rigidbody rb;
    public Animator animator;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2; 
    [SerializeField] float jumpforce = 400f;
    [SerializeField] LayerMask groundMask;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!alive) return; 

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * horizontalMultiplier * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
            Jump();
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
        

        /*if(transform.position.y < -5)
        {
            Die();
        }**/
    }

    public void Die()
    {
        alive = false;
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        //check whether we are grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        
        //if we are, then jump
        if(isGrounded)
        {
            rb.AddForce(Vector3.up * jumpforce);
        }
        //rb.AddForce(Vector3.up * jumpforce);
    }
}
