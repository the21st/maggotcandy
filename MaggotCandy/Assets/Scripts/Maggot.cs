using UnityEngine;
using System.Collections;

public class Maggot : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		transform.localRotation = Quaternion.AngleAxis (Random.Range (0, 360f), new Vector3 (0, 0, 1));
	}
    
	// Update is called once per frame
	void Update()
	{
		var direction = this.transform.right;

		if (Vector3.Dot(transform.up, Vector3.up) < 0)
		{
			transform.localScale = new Vector3(1, -1, 1);
		} else
		{
			transform.localScale = new Vector3(1, 1, 1);
		}

		transform.position += Time.deltaTime * direction;

		transform.Rotate(new Vector3 (0, 0, 1), -1);
	}

	void Crush(PushParams pushParams)
	{
		Destroy(gameObject);
	}
}
