using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkStarter : MonoBehaviour
{
    [SerializeField] private Transform FireworkFatherObject;

    public void StartFireworks()
	{
		for (int i = 0; i < FireworkFatherObject.childCount; i++)
		{
			Transform Fireworks = FireworkFatherObject.GetChild(i);
			for (int j = 0; j < 9; j++)
			{
				Fireworks.GetChild(j).GetComponent<ParticleSystem>().Play();
			}
		}
		
	}
}
