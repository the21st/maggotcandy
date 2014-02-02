using UnityEngine;
using System.Collections;

public class Slime : MonoBehaviour
{
	private float _spillProgress;

	void Start()
	{
		_spillProgress = 0.3f;
	}

	void Update()
	{
		_spillProgress += Time.deltaTime;

		_spillProgress = Mathf.Clamp01(_spillProgress);

		renderer.transform.localScale = new Vector3(_spillProgress, _spillProgress, 1);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		other.SendMessage("StickToSlime", SendMessageOptions.DontRequireReceiver);
	}
}
