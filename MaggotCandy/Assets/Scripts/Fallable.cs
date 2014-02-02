using UnityEngine;
using System.Collections;

public class Fallable : MonoBehaviour {

	void Fall(int layerOrder)
	{
		this.renderer.sortingOrder = layerOrder;
		this.collider2D.enabled = false;
		this.rigidbody2D.gravityScale = 7.5f;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (transform.position.y < -7)
		{
			Destroy(gameObject);
		}
	}
}
