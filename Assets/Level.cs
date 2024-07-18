using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject platformPrefab;

	public int numberOfPlatforms = 200;
	public float width = 1f;
	public float minY = .2f;
	public float maxY = 1.5f;

	// Use this for initialization
	void Start()
	{

		Vector3 spawnPosition = new Vector3();

		for (int i = 0; i < numberOfPlatforms; i++)
		{
			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-width, width);
			Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
		}
	}
}