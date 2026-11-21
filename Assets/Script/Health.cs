using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int hp = 3;
    public AudioClip hurtClip;
    public AudioClip pickupClip;

    bool invincible;
    Renderer rend;
    AudioSource src;

    void Start()
    {
        rend = GetComponent<Renderer>();
        src = GetComponent<AudioSource>();
    }

    public void TakeDamage(int dmg)
    {
        if (invincible) return;

        hp -= dmg;
        Debug.Log("HP: " + hp);
        src.PlayOneShot(hurtClip);

        if (hp <= 0)
        {
            GameOver();
            return;
        }
        StartCoroutine(Invincibility());
    }

    public void Heal(int amount)
    {
        hp += amount;
        Debug.Log("HP: " + hp);
        src.PlayOneShot(pickupClip);
    }

    IEnumerator Invincibility()
    {
        invincible = true;
        for (int i = 0; i < 10; i++)
        {
            rend.enabled = !rend.enabled;
            yield return new WaitForSeconds(0.2f);
        }
        rend.enabled = true;
        invincible = false;
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


