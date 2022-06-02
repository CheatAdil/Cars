using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocket : MonoBehaviour
{
	[SerializeField] private GameObject Rocket;
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) Instantiate(Rocket, transform.position, transform.rotation);
	}
}
