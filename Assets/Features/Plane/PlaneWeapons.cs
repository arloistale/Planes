using UnityEngine;

public class PlaneWeapons : MonoBehaviour
{
    [SerializeField]
    private Missile missilePrefab;

    [SerializeField]
    private float missileSpeed;

    [SerializeField]
    private float missileLifetime;

    public void Fire()
    {
        Missile missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
        missile.Launch(gameObject.transform.forward, missileSpeed, missileLifetime);
    }
}
