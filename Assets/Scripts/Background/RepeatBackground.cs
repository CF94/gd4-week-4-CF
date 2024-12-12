using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    public float scrollSpeed = 10f;
    private float repeatWidth;
    private PlayerController playerControllerScript;
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        transform.Translate (Vector3.left * scrollSpeed * Time.deltaTime);
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
        if (playerControllerScript.isGameOver == true) scrollSpeed = 0f;
    }
}