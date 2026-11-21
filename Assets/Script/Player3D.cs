using UnityEngine;
using UnityEngine.SceneManagement;

public class Player3D : MonoBehaviour
{
    public float force = 14f;
    private Rigidbody rb;
    private int coins;
    private int coinsTotal;
    private Animator gateAnimator;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        coinsTotal = GameObject.FindGameObjectsWithTag("Coin").Length;
        Debug.Log("Coins in this level: " + coinsTotal);

        // находим ворота по тегу Exit и берём их Animator
        GameObject gate = GameObject.FindGameObjectWithTag("Exit");
        if (gate != null)
            gateAnimator = gate.GetComponent<Animator>();
    }

    void Update()
    {
        // упал с арены — рестарт
        if (transform.position.y < -10f)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        rb.AddForce(new Vector3(x, 0f, z) * force);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            Debug.Log("Coins: " + coins + " / " + coinsTotal);

            // все монеты собраны — открываем ворота
            if (coins >= coinsTotal && gateAnimator != null)
                gateAnimator.SetBool("IsOpen", true);
        }
        if (other.CompareTag("Exit"))
        {
            if (coins >= coinsTotal)
                Debug.Log("You win!");
            else
                Debug.Log("Collect all coins first! " + coins + " / " + coinsTotal);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}



