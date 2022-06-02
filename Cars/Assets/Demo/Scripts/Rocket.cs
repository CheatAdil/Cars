using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private float radius;
    [SerializeField] private float force;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private Rigidbody self;
    private void Start()
    {
    }
    private void Update()
    {
        if (dir != Vector3.zero)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, radius, ~6);
        for (int i = 0; i < cols.Length; i++) 
        {
            Rigidbody r;
            if (cols[i].TryGetComponent<Rigidbody>(out r)) 
            {
                r.AddExplosionForce(force, transform.position, radius);
                print($"force: {r.name}");
            }
        }
        GameObject.Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
