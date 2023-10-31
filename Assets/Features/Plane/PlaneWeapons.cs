using UnityEngine;

public class PlaneWeapons : MonoBehaviour
{
    [SerializeField]
    private Missile missilePrefab;

    [SerializeField]
    private float missileSpeed;

    [SerializeField]
    private float missileLifetime;

    [SerializeField]
    private AudioClip fireSound;

    public void Fire()
    {
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
        Missile missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
        missile.Launch(gameObject.transform.forward, missileSpeed, missileLifetime);
    }
}
