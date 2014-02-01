using UnityEngine;
using System.Collections;

public class StonedBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public float progress = 0;
	public Vector2 pos  = new Vector2(20, 40);
	public Vector2 size = new Vector2(20, 60);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, size.y), progressBarEmpty);
		GUI.DrawTexture(new Rect(pos.x, pos.y + size.y * (1-Mathf.Clamp01(progress)), size.x, size.y * Mathf.Clamp01(progress)), progressBarFull);
	}
	
	void Update()
	{
	}
}
