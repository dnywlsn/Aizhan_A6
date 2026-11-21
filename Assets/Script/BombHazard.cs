using UnityEngine;
public class BombHazard : Hazard
{
    public AudioClip boomClip;
    void Start() { Invoke(nameof(Explode), 2f); }

    void Explode()
    {
        if (boomClip) AudioSource.PlayClipAtPoint(boomClip, transform.position);
        Destroy(gameObject);
    }
    protected override void OnHitPlayer(Health p) { CancelInvoke(); p.TakeDamage(2); }
}


