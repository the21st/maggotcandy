using UnityEngine;
using System.Collections;

public class SnortController : MonoBehaviour {

	public float SuckForce = 10;
	public float MaxShake = 1;

	bool _stopped;

	// Use this for initialization
	void Start ()
	{
		_stopped = false;
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (_stopped)
		{
			audio.Stop();
			return;
		}

		var stonedAmount = FindObjectOfType<StonedBar>().GetProgress();
		var shake = Mathf.Lerp(0, 0.05f * MaxShake, 1 - Mathf.Clamp01(1.5f * stonedAmount));
		transform.position = Extensions.GetMousePosition2D() + shake * Random.insideUnitCircle;

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

				var forceScale = SuckForce * (1 - distance / collider.radius);
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

	public void StopMoving()
	{
		_stopped = true;
	}
}
