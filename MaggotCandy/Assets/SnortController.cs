using UnityEngine;
using System.Collections;

public class SnortController : MonoBehaviour {

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
		}
	}

	void Snort ()
	{
		var collider = this.GetComponent<CircleCollider2D>();
		var snortPoint = this.transform.position.To22D() + collider.center;
		var suckedObjects = Physics2D.OverlapCircleAll (snortPoint, collider.radius);

		foreach (var suckedObject in suckedObjects)
		{
			if (suckedObject && suckedObject.rigidbody2D)
			{
				var distance = Vector3.Distance(suckedObject.transform.position, collider.center);
				var forceScale = 3 * (1 - distance / collider.radius);
				var forceDir = suckedObject.transform.position.To22D() - snortPoint;
				forceDir.Normalize();
				suckedObject.rigidbody2D.AddForce(forceScale * forceDir);
			}
		}
	}
}
