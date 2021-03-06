﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBloop : MonoBehaviour
{
	public float speed;
	public Transform moveSpot;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;


	public float startWaitTime;
	private float waitTime;
	private Vector2 currentLocation;
	private Vector2 destination;
	private float angle;
	private bool angleSet = false;

	// Start is called before the first frame update
	void Start()
	{
		SetPositionAndMoveTo();
	}

	void SetPositionAndMoveTo()
	{
		moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
		//sets the wait time so that the first time the bloop goes to a location, it will pause
		waitTime = startWaitTime;
	}

    // Update is called once per frame
    void Update()
    {
		currentLocation = transform.position;
		destination = moveSpot.position;
		transform.position = Vector2.MoveTowards(currentLocation, destination, speed * Time.deltaTime);
		
		if (angleSet == false)
		{
			// Determines the angle (the -90 caters for the fact that the angle is calculated from the left side but the front of the sprite is at the top of the image)
			angle = Mathf.Atan2(destination.y - currentLocation.y, destination.x - currentLocation.x) * 180 / Mathf.PI - 90;
			// rotates the bloop by the angle in the z axis
			transform.rotation = Quaternion.Euler(0, 0, angle);
			angleSet = true;
		}

		if (Vector2.Distance(currentLocation, destination) < 0.2f)
		{
			if (waitTime <= 0)
			{
				SetPositionAndMoveTo();
				waitTime = startWaitTime;
				angleSet = false;
			} 
			else
			{
				waitTime -= Time.deltaTime;
			}
		}
    }
}
