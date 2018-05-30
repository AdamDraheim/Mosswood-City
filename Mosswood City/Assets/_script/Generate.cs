using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

    public int sizeX, sizeY;
    public GameObject tower1, tower2, house, shop, street;

    private double[,] height;

	// Use this for initialization
	void Start () {

        height = new double[sizeX, sizeY];

        for(int i = 0; i < sizeX; i++)
        {
            for(int j = 0; j < sizeY; j++)
            {

                if(i != 0 && j != 0)
                {
                    height[i, j] = ((height[i - 1, j] + height[i, j - 1]) / 2) + (Random.Range(0, 5) - 2);

                    if(height[i, j] < -5)
                    {
                        height[i, j] = -5;
                    }
                    if(height[i, j] > 7)
                    {
                        height[i, j] = 7;
                    }

                }
                else
                {
                    height[i, j] = 0;
                }


            }
        }

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {

                GameObject toSpawn = chooseObject(height[i,j]);

                if(i % 3 == 0 || j % 5 == 0)
                {
                    toSpawn = street;
                }

                Instantiate(toSpawn, new Vector3(i, toSpawn.GetComponent<Renderer>().bounds.size.y / 2, j), new Quaternion(0, 0, 0, 0));

            }
        }

    }

    private GameObject chooseObject(double height)
    {
        GameObject toSpawn = null;

        if(height < -3)
        {
            toSpawn = shop;
        }else if(height < 2)
        {
            toSpawn = house;
        }else if(height < 5)
        {
            toSpawn = tower1;
        }
        else
        {
            toSpawn = tower2;
        }
        return toSpawn;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
