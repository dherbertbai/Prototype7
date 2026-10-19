using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    //My art
    public SpriteRenderer Body;
    public SpriteRenderer Tile;
    public GameObject TilePrefab;
    public bool Fell;
    
    //What's inside of me?
    public TileContentsController Contents;
    
    //Where am I?
    public int X;
    public int Y;
    
    public float rand;
    public int mode;
    public float timer;

    //This gets called by GridManager when it spawns me
    public void Setup(int x, int y)
    {
        //Record where I am on the map
        X = x;
        Y = y;
    }

    //This function finds the tile that's X units to my right and Y above me
    //It's used for character movement--if a character wants to move one tile up they look for X:0,Y:1
    public TileController Neighbor(int x, int y)
    {
        //Ask the GridManager for the tile that's where I am, but with the requested offset
        return GridManager.Me.GetTile(X + x, Y + y);
    }

    public void Start()
    {
        rand = UnityEngine.Random.Range(5, 18);
        timer = rand;
        mode = 0;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (mode == 3)
            {
                mode = 0;
            }
            else
            {
                mode ++;
            }
            timer = rand;
        }
        if (mode == 0)
        {
            rand = UnityEngine.Random.Range(5, 18);
            Tile.color = Color.white;
            Fell = false;
        }
        else if (mode == 1)
        {
            rand = UnityEngine.Random.Range(3, 7);
            Tile.color = Color.yellow;
        }
        else if (mode == 2)
        {
            rand = UnityEngine.Random.Range(2, 4);
            Tile.color = Color.orange;
        }
        else
        {
            rand = UnityEngine.Random.Range(5, 8);
            Tile.color = Color.red;
            Fell = true;
            if (Contents != null)
            {
                Contents.Die();
            }
        }
    }
}
