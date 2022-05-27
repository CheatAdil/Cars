using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    [SerializeField] private float speed;

    private void Start()
    {
        if (dir != Vector3.zero) transform.LookAt(transform.position + dir);
    }
    private void Update()
    {
        if (dir != Vector3.zero)
        { 
            transform.position += dir.normalized * speed * Time.deltaTime;
        }
    }
}
