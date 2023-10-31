using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minForce = 5f;
    public float maxForce = 20f;
    public float minTorque = 10f;
    public float maxTorque = 50f;

    public GameObject explosionPrefab;

    public AudioClip explosionSound;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Push()
    {
        // Generate random force and apply it for movement
        Vector3 randomForce = new Vector3(
            Random.Range(-1f, 1f), 
            Random.Range(-1f, 1f), 
            Random.Range(-1f, 1f)
        ).normalized * Random.Range(minForce, maxForce);

        rb.AddForce(randomForce, ForceMode.Impulse);

        // Generate random torque and apply it for rotation
        Vector3 randomTorque = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized * Random.Range(minTorque, maxTorque);

        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destructive"))
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Destroy(other.gameObject);
            Explode();
        }
    }

    private void Explode()
    {
        var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 1.1f);

        Destroy(gameObject);
    }
}
