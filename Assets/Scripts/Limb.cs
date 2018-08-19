using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Limb : MonoBehaviour {

	public IEnumerator FadeTo(float initValue, float duration, float timeUntilStart)
	{
		yield return new WaitForSeconds(timeUntilStart);

		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		Color newColor = new Color(1, 1, 1, 0);
		renderer.color = newColor;

		float alpha = renderer.color.a;

		for(float t = 0f; t < 1f; t += Time.deltaTime / duration)
		{
			newColor = new Color(1, 1, 1, Mathf.Lerp(initValue, alpha, t));
			renderer.color = newColor;

			if(t > .98f)
			{
				Destroy(gameObject);
			}

			yield return null;
		}
	}
}
