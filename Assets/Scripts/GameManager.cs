using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//audio
	private AudioSource source;
	public AudioClip countDownAudioClip;
	public AudioClip holdMyBeerAudioClip;
	private bool isBeerHeld = false;

	//game clock
	public float maxGameTime;
	public float currentGameTime;

	public Transform[] enemySpawnPoints;
	public GameObject enemyPrefab;
	[SerializeField]
	private float spawnBaseCooldown;

	// Use this for initialization
	void Start () {
		currentGameTime = 0;

		source = GetComponent<AudioSource>();
		source.PlayOneShot(countDownAudioClip);

		StartCoroutine(Spawner());
	}
	
	// Update is called once per frame
	void Update () {
		currentGameTime += Time.deltaTime;

		if (currentGameTime >= 2.5f && !isBeerHeld)
		{
			isBeerHeld = true;
			source.PlayOneShot(holdMyBeerAudioClip);
		}
	}
	
	IEnumerator Spawner()
	{
		SpawnEnemy(enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)]);
		yield return new WaitForSeconds(spawnBaseCooldown);
		StartCoroutine(Spawner());
		yield return null;
	}

	void SpawnEnemy(Transform spawnPoint)
	{
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
