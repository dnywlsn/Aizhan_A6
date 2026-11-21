using UnityEngine;
public class Shooter : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float cooldown = 0.3f;
    public AudioClip shootClip;
    float nextShot;
    Vector3 lastDir = Vector3.right;
    AudioSource src;

    void Start() { src = GetComponent<AudioSource>(); }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (move != Vector3.zero) lastDir = move.normalized;

        if (Input.GetKey(KeyCode.X) && Time.time >= nextShot)
        {
            nextShot = Time.time + cooldown;
            Bullet b = Instantiate(bulletPrefab, transform.position + lastDir, Quaternion.identity);
            b.Launch(lastDir);
            if (shootClip) src.PlayOneShot(shootClip);
        }
    }
}



