using UnityEngine;
public class SurvivalTimer : MonoBehaviour
{
    public float goal = 60f;
    public Animator gateAnimator;   // ворота с анимацией из A5 (если есть)
    public GameObject gateObject;   // запасной вариант: объект, который исчезнет
    float t; bool won;

    void Update()
    {
        t += Time.deltaTime;
        if (!won && t >= goal)
        {
            won = true;
            Debug.Log("YOU WIN!");
            if (gateAnimator) gateAnimator.SetBool("Open", true);
            if (gateObject) gateObject.SetActive(false);
        }
    }
}
