using UnityEngine;
public class Hazard : MonoBehaviour
{
    void Start() { Destroy(gameObject, 15f); }   // чтобы упавшее не копилось

    void OnCollisionEnter(Collision c)
    {
        if (!c.gameObject.CompareTag("Player")) return;
        OnHitPlayer(c.gameObject.GetComponent<Health>());
        Destroy(gameObject);
    }
    protected virtual void OnHitPlayer(Health player) { player.TakeDamage(1); }
}

