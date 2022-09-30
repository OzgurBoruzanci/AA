using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircle : MonoBehaviour
{
    public GameObject SmallCircle;
    GameObject GameController;
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameControllerTag");
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CreateSmallCircle();
        }
    }
    void CreateSmallCircle()
    {
        Instantiate(SmallCircle, transform.position, transform.rotation);
        GameController.GetComponent<GameControllerCodes>().ShowTextInSmallCircle();
    }
}
