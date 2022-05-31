using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
public class Booster : MonoBehaviour
{
    private ArcadeKart kart;
    [SerializeField] private float plus_speed;
    [SerializeField] private float plus_acc;
    [SerializeField] private float plus_steer;
    [SerializeField] private float duration;
    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.tag == "Ride") 
        {
            kart = other.GetComponentInParent<ArcadeKart>();
            if (kart != null)
            {
                ArcadeKart.Stats mod;
                mod = new ArcadeKart.Stats();
                mod.TopSpeed = plus_speed;
                mod.Acceleration = plus_acc;
                mod.Steer = plus_steer;
                ArcadeKart.StatPowerup powerup;
                powerup = new ArcadeKart.StatPowerup();
                powerup.modifiers = mod;
                powerup.MaxTime = duration;
                kart.AddPowerup(powerup);
            }
        }
    }
}
