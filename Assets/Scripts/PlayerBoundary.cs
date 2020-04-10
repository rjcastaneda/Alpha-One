using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screen;
    private float playerWidth;
    private float playerHeight;
    private float cameraHeight;
    private float cameraWidth;



    void Start()
    {

        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;
        screen = new Vector2(cameraHeight, cameraWidth);
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = this.gameObject.transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screen.x + playerWidth, screen.x * -1 - playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screen.y + playerHeight, screen.y * -1 - playerHeight);
    }
}
