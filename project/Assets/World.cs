using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
	int[] WorldSize = new int[] {20, 15, 10, 1000}; //xyz and num of blocks
	int[] BlockData = new int[20*15*10];
	
 	void CreateVoxel(int x, int y, int z, int id) 
	{
		bool front1, top1, right1, left1, back1, bottom1;
		
		if (z != 0)
		{
		    if (BlockData[id-WorldSize[0]] == 0)
		    {
		    front1 = true;
		    } 
			else 
			{
			front1 = false;
			}
	    } 
		else 
		{
		    front1 = true;
	    }
		
		if (y != WorldSize[1]-1)
		{
		    if (BlockData[id+(WorldSize[0]*WorldSize[2])] == 0)
		    {
		    top1 = true;
		    } else {
			top1 = false;
			}
	    } else {
		    top1 = true;
	    }
		
		if (x != WorldSize[0]-1)
		{
		    if (BlockData[id+1] == 0)
		    {
		    right1 = true;
		    } 
			else 
			{
			right1 = false;
			}
	    } 
		else 
		{
		    right1 = true;
	    }
		
		if (x != 0)
		{
		if (BlockData[id-1] == 0)
		{
		    left1 = true;
		} 
		else 
		{
			left1 = false;
		}
	    } 
		else 
		{
		    left1 = true;
	    }
		
		if (z != WorldSize[2]-1)
		{
		    if (BlockData[id+WorldSize[0]] == 0)
		    {
		    back1 = true;
		    } 
			else 
			{
			back1 = false;
			}
	    } 
		else 
		{
		    back1 = true;
	    }
		
		if (y != 0)
		{
		    if (BlockData[id-(WorldSize[0]*WorldSize[2])] == 0)
		    {
		    bottom1 = true;
		    } else {
			bottom1 = false;
			}
	    } else {
		    bottom1 = true;
	    }
		
		Debug.Log(bottom1);
		Debug.Log(front1 && top1 && right1 && left1 && back1 && bottom1);
		    if (front1 || top1 || right1 || left1 || back1 || bottom1) {
			CreateBlock BlockCreator = GetComponent<CreateBlock>();
	        BlockCreator.CreateCube(back1, top1, right1, left1, front1, bottom1, id, x, y, z);
			//BlockCreator.CreateCube(false, true, true, true, true, true, id, x, y, z);
	        }
    }
	
	
	void GenerateWorld()
	{
		for (int i = 0; i < BlockData.Length; i++) 
		{
			BlockData[i] = 1;
	    }
    }
	
	void CreateWorld()
	{
		int crx, cry, crz;
		crx = cry = crz = 0;
		
		for (int i = 0; i < BlockData.Length; i++) 
		{
			if (BlockData[i] == 1) 
			{
				CreateVoxel(crx,cry,crz,i);
			}
			
			crx++;
			if (crx > WorldSize[0]-1)
			{
			    crx=0;
				crz++;
			}
			if (crz > WorldSize[2]-1)
			{
				crz=0;
				cry++;
		    }
	    }
		
    }

    void Start() 
	{
    GenerateWorld();
	CreateWorld();
	}
}
