using UnityEngine;
using UnityEngine.UIElements;

public class Foot : MonoBehaviour
{
    private float moveSpeed = 10;
    public float yRange = 5;
    private PlayerController playerControllerScript;
    public ParticleSystem explosionParticle;
    private AudioSource audioSource;
    public AudioClip fartSound;
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isGameOver == true)  
        {
            if (transform.position.y > yRange)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            }
            if (transform.position.y < yRange) moveSpeed = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            explosionParticle.Play();
            audioSource.PlayOneShot(fartSound);
        }
    }
}
