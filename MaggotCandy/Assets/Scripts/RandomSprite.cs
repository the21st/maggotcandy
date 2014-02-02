using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSprite : MonoBehaviour
{
	public List<Sprite> Sprites;

	// Use this for initialization
	void Start()
	{
		if (Sprites.Count > 0)
		{
			GetComponent<SpriteRenderer>().sprite = Sprites.GetRandomElement();
		}
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}
}
