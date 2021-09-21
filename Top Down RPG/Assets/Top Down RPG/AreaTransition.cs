﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    public Vector2 maxpos, minpos;
    public Vector2 camTransition;
    public Vector3 playerTransition;
    private SmoothCamera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<SmoothCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            cam.MinPos = minpos;
            cam.MaxPos = maxpos;
            collision.transform.position += playerTransition;
        }
    }
}
