using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public LogicScript logicScript;

    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bird")
        {
            logicScript.AddScore();
        }
    }
}
