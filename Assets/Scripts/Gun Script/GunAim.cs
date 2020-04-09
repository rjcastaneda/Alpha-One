using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour
{

    private Transform crosshairTransform;
    private Vector3 mousePos;
    private Vector3 aimDir;
    private Transform gunConstraint;
    private Camera cam;

    void Awake()
    {
        //Intialize variables.
        crosshairTransform = GameObject.Find("Crosshair").GetComponent<Transform>();
        gunConstraint = GameObject.Find("GunHolder").GetComponent<Transform>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        crosshairTransform.position = new Vector2(mousePos.x,mousePos.y);
        aimDir = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        gunConstraint.eulerAngles = new Vector3(0,0,angle);
    }
}
