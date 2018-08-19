using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour {

	[Range(0, 10)]
	public float fadeTime = 1f, timeUntilStart = 2f;
	Color color_a1 = new Color(1, 1, 1, 1);
	Color color_a0 = new Color(0, 0, 0, 0);

	public List<RigidLimb> rigidLimbList;
	public GameObject Limbs;

	private void Start()
	{
		ListInitialize();
	}
	
	public void BreakApart()
	{
		Limbs.SetActive(true);

		foreach (RigidLimb limb in rigidLimbList)
		{
			limb.limbPrefabRenderer.color = color_a1;

			limb.limbPrefab.SetActive(true);
			limb.limbPrefab.transform.position = limb.limbBone.transform.position;
			limb.limbPrefab.transform.rotation = Quaternion.identity;

			limb.limbPrefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, limb.detachForce), ForceMode2D.Impulse);
			limb.limbPrefab.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-limb.detachRotationForce, limb.detachRotationForce), ForceMode2D.Impulse);

			limb.limbBoneMesh.color = color_a0;

			limb.limbPrefab.GetComponent<Limb>().StartCoroutine(limb.limbPrefab.GetComponent<Limb>().FadeTo(1f, fadeTime, timeUntilStart));
		}
	}

	private void ListInitialize()
	{
		for (int i = 0; i < rigidLimbList.Count; i++)
		{
			rigidLimbList[i].limbPrefabRenderer = rigidLimbList[i].limbPrefab.GetComponent<SpriteRenderer>();
			rigidLimbList[i].limbPrefab.SetActive(false);
		}
	}
}
