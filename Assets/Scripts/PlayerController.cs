using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Rigidbody rb;
    public float jumpForce = 10f;    
    public bool isOnGround = true;
    public float gravityModifier = 2;
    private int jumpCount = 0;
    private int maxJumpCount = 2;
    public bool isGameOver = false;    
    Animator anim;
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            dirtParticle.Stop();
            if (isOnGround && jumpCount < maxJumpCount && isGameOver == false)
            {                
                rb.linearVelocity = Vector3.zero;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                jumpCount++;
                anim.SetTrigger("Jump_trig");                
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Physics.gravity /= gravityModifier;
            SceneManager.LoadScene(0);
        }        
    }    
    //void Jump() { }

    private void OnCollisionEnter(Collision collision)    
    {
        //isOnGround = true;
        if (collision.transform.tag == "Obstacle")
        {
            dirtParticle.Stop();
            isGameOver = true;
            anim.SetBool("Death_b", true);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }        
        jumpCount = 0;
    }    
}
