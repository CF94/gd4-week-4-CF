using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float moveSpeed = 10;
    public float xRange = -10;
    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {        
        //transform.Translate(Vector3.left * Time.deltaTime *moveSpeed);

        if (playerControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }

        if (transform.position.x < xRange)
        {
            Destroy(gameObject);
        }
    }
}
