using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 5;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    void SpawnPipe()
    {
        float pipeY = Random.Range(-heightOffset, heightOffset);
        Instantiate(pipePrefab, transform.position + Vector3.up * pipeY, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
    }
}
