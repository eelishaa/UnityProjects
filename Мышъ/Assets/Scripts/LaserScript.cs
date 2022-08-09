﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    //1
    public Sprite laserOnSprite;
    public Sprite laserOffSprite;

    //2    
    public float interval = 0.5f;
    public float rotationSpeed = 0.0f;

    //3
    private bool isLaserOn = true;
    private float timeUntilNextToggle;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilNextToggle = interval;
    }

    void FixedUpdate()
    {
        //1
        timeUntilNextToggle -= Time.fixedDeltaTime;

        //2
        if (timeUntilNextToggle <= 0)
        {

            //3
            isLaserOn = !isLaserOn;

            //4
            GetComponent<Collider2D>().enabled = isLaserOn;

            //5
            SpriteRenderer spriteRenderer = ((SpriteRenderer)this.GetComponent<Renderer>());
            if (isLaserOn)
                spriteRenderer.sprite = laserOnSprite;
            else
                spriteRenderer.sprite = laserOffSprite;

            //6
            timeUntilNextToggle = interval;
        }

        //7
        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.fixedDeltaTime);
    }
}
