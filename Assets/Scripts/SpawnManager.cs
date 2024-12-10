using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] obstaclePrefab;    
    private Vector3 spawnPosition = new Vector3 (24, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);        
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
        Instantiate(obstaclePrefab[obstacleIndex], spawnPosition, Quaternion.identity);
    }
}
