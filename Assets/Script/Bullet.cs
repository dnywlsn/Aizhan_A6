using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public void Launch(Vector3 dir)
    {
        GetComponent<Rigidbody>().linearVelocity = dir * speed;
        Destroy(gameObject, 3f);   // самоуничтожение через 3 сек
    }
}
