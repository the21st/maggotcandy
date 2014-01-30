using UnityEngine;
using System.Collections;

public class FallTrigger : MonoBehaviour {

	public int ChangeLayerOrder;

	void OnTriggerEnter2D(Collider2D other)
	{
		other.SendMessage("Fall", ChangeLayerOrder);
	}
}
