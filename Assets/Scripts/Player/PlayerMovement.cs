using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 mousePos;
    private Camera cam;


    // Start is called before the first frame update
    void Awake()
    {
        //Intialize variables.
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        playerTransform.position = new Vector3(mousePos.x, mousePos.y, -1);
    }
}
