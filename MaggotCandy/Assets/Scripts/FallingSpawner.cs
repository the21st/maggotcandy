using UnityEngine;
using System.Collections;

public class FallingSpawner : MonoBehaviour
{
	public Vector2 Target;
	public GameObject PrefabToCreate;

	private bool _falling;

	// Use this for initialization
	void Start()
	{
		GetComponent<SpriteRenderer>().sprite = PrefabToCreate.GetComponent<SpriteRenderer>().sprite;

		_falling = rigidbody2D.gravityScale > 0;

		if (_falling)
		{
			transform.position = (Target + new Vector2(0, 5)).To3D();
		} else
		{
			transform.position = (Target + new Vector2(0, -5)).To3D();
		}

		rigidbody2D.AddTorque(Random.Range(-4000, 4000));
	}
	
	// Update is called once per frame
	void Update()
	{
		var height = _falling ? transform.position.y : -transform.position.y;

		if (height < Target.y)
		{
			var newGameObject = (GameObject) Instantiate(PrefabToCreate, transform.position, transform.rotation);
			newGameObject.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;

			Destroy(gameObject);
		}
	}
}
