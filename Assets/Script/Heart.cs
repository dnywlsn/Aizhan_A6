using UnityEngine;
public class Heart : Hazard
{
    public AudioClip pickupClip;
    protected override void OnHitPlayer(Health p)
    {
        p.Heal(1);
        if (pickupClip) AudioSource.PlayClipAtPoint(pickupClip, transform.position);
    }
}

