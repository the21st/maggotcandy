using UnityEngine;
using System.Collections;

public class Slime : MonoBehaviour
{
	void Start()
	{
	}

	void Update()
	{
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		other.SendMessage("StickToSlime", SendMessageOptions.DontRequireReceiver);
	}
}
