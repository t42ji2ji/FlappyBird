using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float speed = 10;
    private float destroyX = -25;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destroyX)
        {
            Debug.Log("Destroying pipe");
            Destroy(gameObject);
        }
        transform.position -= Vector3.right * speed * Time.deltaTime;
    }
}
