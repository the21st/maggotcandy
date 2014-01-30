using UnityEngine;
using System.Collections;

public class Fallable : MonoBehaviour {

	void Fall(int layerOrder)
	{
		this.renderer.sortingOrder = layerOrder;
		this.collider2D.enabled = false;
		this.rigidbody2D.gravityScale = 10;
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}
}
