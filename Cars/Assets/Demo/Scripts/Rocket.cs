using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private float radius;
    [SerializeField] private float force;

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
    private void OnCollisionEnter(Collision collision)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, radius, ~2);
        for (int i = 0; i < cols.Length; i++) 
        {
            Rigidbody r;
            if (cols[i].TryGetComponent<Rigidbody>(out r)) 
            {
                r.AddExplosionForce(force, transform.position, radius);
            }
        }
        print(cols.Length);
        Destroy(this.gameObject);
    }
}
