using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float lifetime = 5f; // Time after which the missile will be destroyed

    private float speed;

    public void Launch(Vector3 direction, float speed, float lifetime)
    {
        transform.forward = direction;
        this.speed = speed;

        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        transform.Translate(transform.forward * moveDistance);
    }
}
