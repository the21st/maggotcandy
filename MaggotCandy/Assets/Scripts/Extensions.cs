using UnityEngine;

public static class Extensions
{
	public static Vector3 To2D(this Vector2 v)
	{
		return new Vector3(v.x, v.y, 0);
	}

	public static Vector2 To22D(this Vector3 v)
	{
		return new Vector2(v.x, v.y);
	}
	
	public static Vector2 GetMousePosition2D()
	{
		return Extensions.To2D (Camera.main.ScreenToWorldPoint (Input.mousePosition));
	}
	
	public static Vector2 GetMousePosition3D()
	{
		return Camera.main.ScreenToWorldPoint (Input.mousePosition);
	}

	public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius)
		
	{
		
		var dir = (body.transform.position - explosionPosition);
		
		float wearoff = 1 - (dir.magnitude / explosionRadius);

		if (wearoff < 0)
		{
			wearoff = 0;
		}
		
		body.AddForce(dir.normalized * explosionForce * wearoff);
		
	}
	
	
	
	public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius, float upliftModifier)
		
	{
		
		var dir = (body.transform.position - explosionPosition);
		
		float wearoff = 1 - (dir.magnitude / explosionRadius);
		
		Vector3 baseForce = dir.normalized * explosionForce * wearoff;
		
		body.AddForce(baseForce);
		
		
		
		float upliftWearoff = 1 - upliftModifier / explosionRadius;
		
		Vector3 upliftForce = Vector2.up * explosionForce * upliftWearoff;
		
		body.AddForce(upliftForce);
		
	}
}
