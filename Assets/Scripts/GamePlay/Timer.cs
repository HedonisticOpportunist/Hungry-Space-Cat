using UnityEngine;

public class Timer: MonoBehaviour
{
    [Header("Pause Player and Enemy Movement Time")]
    [SerializeField] float timeLeft = 3.0f;
    public static bool timerFinished;

    void Awake()
    {
        timerFinished = false;
    }

    private void Update()
    {
        StartCountdown();
    }

    public void StartCountdown()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timerFinished = true;
        }
    }
}