using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop : MonoBehaviour
{
    private float scrollSpeed = -1f;
    private float bgSizeY = 16f;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, bgSizeY);
        this.transform.position = startPos + Vector3.up * newPosition;
    }
}
