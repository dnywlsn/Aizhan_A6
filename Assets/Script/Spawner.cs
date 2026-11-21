using UnityEngine;
public class Spawner : MonoBehaviour
{
    public Hazard[] prefabs;   // сюда Rock, Bomb, Heart
    public float areaX = 8f;
    public float areaZ = 8f;
    public float height = 8f;

    void Start() { InvokeRepeating(nameof(Spawn), 1f, 2f); }

    void Spawn()
    {
        Hazard pick = prefabs[Random.Range(0, prefabs.Length)];
        Vector3 pos = new Vector3(Random.Range(-areaX, areaX), height, Random.Range(-areaZ, areaZ));
        Instantiate(pick, pos, Quaternion.identity);
    }
}
