using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopEnd : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ride") LoopEndEvents();
	}
	private void LoopEndEvents()
	{
		GetComponent<FireworkStarter>().StartFireworks();
	}
}
