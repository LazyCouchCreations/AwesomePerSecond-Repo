using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public IEnumerator Shake(float duration, float magnitude)
	{
		Vector3 originalPosition = transform.localPosition;
		Vector3 originalRotation = transform.eulerAngles;

		float elapsed = 0f;

		while (elapsed < duration)
		{
			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range(-1f, 1f) * magnitude;
			float rot = Random.Range(-10f, 10f) * magnitude;

			transform.localPosition = new Vector3(x, y, originalPosition.z);
			transform.eulerAngles = new Vector3(originalRotation.x, originalRotation.y, rot);

			elapsed += Time.deltaTime;
			yield return null;
		}

		transform.localPosition = originalPosition;
		transform.eulerAngles = originalRotation;
	}
}
