﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

    public GameObject[] ObstaclesToGenerate;
    public int obstacleMinHeight, obstacleMaxHeight;
    public float minInterval, maxInterval;

    float timer;
    float randomInterval;
    int randomObstacleHeight;

    void Start ()
    {
        GenerateRandomInterval();
	}

    void Update ()
    {
        timer += Time.deltaTime;
        
        if (timer >= randomInterval)
        {
            InstantiateGameObjects();
            timer = 0f;
            GenerateRandomInterval();
        }
    }

    void GenerateRandomInterval()
    {
        randomInterval = Random.Range(minInterval - 0.01f, maxInterval - 0.01f);
    }

    void InstantiateGameObjects()
    {
        float minIndex = 0.01f;
        float maxIndex = ObstaclesToGenerate.Length - 0.01f;
        int randomIndex = (int)Mathf.Floor(Random.Range(minIndex, maxIndex));

        float minHeight = 1.01f;
        float maxHeight = obstacleMaxHeight + 1 - 0.01f;
        int randomHeight = (int)Mathf.Floor(Random.Range(minHeight, maxHeight));

        Debug.Log("instantiating " + ObstaclesToGenerate[randomIndex].name + " height: " + randomHeight);
        float objectHeight = ObstaclesToGenerate[randomIndex].GetComponent<SpriteRenderer>().bounds.size.y + .015f;
        for (int i = 0; i < randomHeight; i++)
        {
            Instantiate(ObstaclesToGenerate[randomIndex], new Vector2(transform.position.x, transform.position.y + i * objectHeight), Quaternion.identity);
        }

    }
}