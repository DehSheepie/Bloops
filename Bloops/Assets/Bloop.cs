using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloop : MonoBehaviour
{
	public Transform location;
	public float speed;

	private Quaternion currentFacing;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			SetLocation();
		}

		transform.position = Vector2.MoveTowards(transform.position, location.transform.position, speed * Time.deltaTime);
		if ((Vector2)transform.position != (Vector2)location.position)
		{
			// Determines the angle (the -90 caters for the fact that the angle is calculated from the left side but the front of the sprite is at the top of the image)
			float angle = Mathf.Atan2(transform.position.y - location.transform.position.y, transform.position.x - location.transform.position.x) * 180 / Mathf.PI + 90;
			// rotates the bloop by the angle in the z axis
			currentFacing = Quaternion.Euler(0, 0, angle);
			transform.rotation = currentFacing;  // Records the direction the AI is currently facing so that it can be used when the AI reaches it's destination
		}

		if ((Vector2)transform.position == (Vector2)location.position)  // Casts both the vectors as vector2 so the z axis isn't taken into account in the comparison
		{
			transform.rotation = currentFacing;
		}
		
	}

	void SetLocation()
	{
		location.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}
