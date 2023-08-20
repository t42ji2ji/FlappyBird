using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeChild : MonoBehaviour
{
    // Start is called before the first frame update
    public LogicScript logicScript;
    public BirdScript birdScript;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.gamerOver();
        birdScript.Die();
    }

    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").
        GetComponent<LogicScript>();
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update() { }
}
