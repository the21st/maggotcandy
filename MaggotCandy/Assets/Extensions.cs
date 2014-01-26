using UnityEngine;

	public static class Extensions
	{
		public static Vector3 To2D(this Vector2 v)
		{
			return new Vector3(v.x, v.y, 0);
		}
	}
