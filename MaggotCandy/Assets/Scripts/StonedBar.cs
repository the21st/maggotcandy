using UnityEngine;
using System.Collections;

public class StonedBar : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		_progress = StonedStartValue;
	}

	public float StonedDecaySpeed = 0.05f;
	public float StonedStartValue = 0.5f;

	private static float _progress = 0;
	public Vector2 pos  = new Vector2(20, 40);
	public Vector2 size = new Vector2(20, 60);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;

	public static void Add(float x)
	{
		_progress += x;
		_progress = Mathf.Clamp01 (_progress);
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, size.y), progressBarEmpty);
		GUI.DrawTexture(new Rect(pos.x, pos.y + size.y * (1-Mathf.Clamp01(_progress)), size.x, size.y * Mathf.Clamp01(_progress)), progressBarFull);
	}
	
	void Update()
	{
		_progress -= StonedDecaySpeed *  Time.deltaTime;

		if (_progress <= 0)
		{
			Application.LoadLevel("gameOver");
		}

		_progress = Mathf.Clamp01 (_progress);
	}
}
