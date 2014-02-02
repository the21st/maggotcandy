﻿using UnityEngine;
using System.Collections;

public class SnortController : MonoBehaviour {

	public float SnortDistance = 0.1f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.position = Extensions.GetMousePosition2D();

		if (Input.GetMouseButton (0))
		{
			Snort();
			if (!audio.isPlaying)
			{
				audio.Play();
			}
		}
		else
		{
			audio.Stop();
		}
	}

	void Snort ()
	{
		var collider = this.GetComponent<CircleCollider2D>();
		var snortPoint = Extensions.To2D(this.transform.position) + collider.center;
		var suckedObjects = Physics2D.OverlapCircleAll (snortPoint, collider.radius);

		foreach (var suckedObject in suckedObjects)
		{
			if (suckedObject && suckedObject.rigidbody2D)
			{
				var suckedObjectPos = suckedObject.transform.position.To2D ();
				var distance = Vector2.Distance (suckedObjectPos, snortPoint);

				if (distance > collider.radius)
				{
					distance = collider.radius;
				}

				var forceScale = 10 * (1 - distance / collider.radius);
				var forceDir = snortPoint - suckedObjectPos;
				forceDir.Normalize();
				suckedObject.rigidbody2D.AddForce(forceScale * forceDir);
			}
		}

		var snortedObjects = Physics2D.OverlapPointAll(snortPoint);
		foreach (var snortedObject in snortedObjects)
		{
			snortedObject.SendMessage("GetSnorted", SendMessageOptions.DontRequireReceiver);
		}
	}
}
