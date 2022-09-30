using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCircleCode : MonoBehaviour
{
    Rigidbody2D physics;
    public float Speed;
    bool motionControl=false;
    GameObject gameController;


    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameControllerTag");
    }

    
    void FixedUpdate()
    {
        if (!motionControl)
        {
            physics.MovePosition(physics.position + Vector2.up * Speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="turningCircleTag")
        {
            transform.SetParent(col.transform);
            motionControl = true;
        }
        if (col.tag=="SmallCircleTag")
        {
            gameController.GetComponent<GameControllerCodes>().GameOver();
        }
    }

}
