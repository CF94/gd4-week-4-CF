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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround || jumpCount < maxJumpCount)
            {
                rb.linearVelocity = Vector3.zero;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                jumpCount++;                
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Physics.gravity /= gravityModifier;
            SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
        jumpCount = 0;
    }

}
