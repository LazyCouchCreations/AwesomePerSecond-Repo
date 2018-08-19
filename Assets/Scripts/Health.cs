using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Break))]
public class Health : MonoBehaviour
{

	public GameObject orbPrefab;
	public int health;

	public void takeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		//break apart the skeleton
		gameObject.GetComponent<Break>().BreakApart();

		//spawn a globe
		Instantiate(orbPrefab, transform.position, transform.rotation);

		//clean up
		StartCoroutine(destoyObject());
		gameObject.layer = 0;
		gameObject.tag = "Untagged";
	}

	public IEnumerator destoyObject()
	{
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}
}
