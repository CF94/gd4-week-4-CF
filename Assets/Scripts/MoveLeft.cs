using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float moveSpeed = 10;
    public float xRange = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime *moveSpeed);
        if (transform.position.x < xRange)
        {
            Destroy(gameObject);
        }
    }
}
