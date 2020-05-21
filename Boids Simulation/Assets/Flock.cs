﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public GameObject[] birds;

    public GameObject[] obstacle;

    public GameObject Bird;

    public GameObject explosionEffect;

    public int numberOfBirds;

    public bool seekGoal = true;

    [Range(0, 2)]
    public float maxForce = 0.5f;

    [Range(0, 100)]
    public float maxVelo = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        birds = new GameObject[numberOfBirds];
        obstacle = new GameObject[11];

        for (int i = 0; i < 11; i++)
        {
            obstacle[i] = this.transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < numberOfBirds; i++)
        {
            Vector3 spawnPosition =
                Random.insideUnitCircle * numberOfBirds * 0.9f;

            //avoid being spawned on the obstacle
            birds[i] =
                Instantiate(Bird, spawnPosition, Quaternion.identity) as
                GameObject;
            birds[i].name = "Bird " + i;
            birds[i].GetComponent<Bird>().manager = this.gameObject;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePos =
                new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y,
                    -10.0f);
            Vector3 bombCentre = Camera.main.ScreenToWorldPoint(mousePos);

            Instantiate(explosionEffect, bombCentre, Quaternion.identity);
        }
    }
}