using System;
using TMPro;
using UnityEngine;

public class DownTimer : MonoBehaviour
{
    public event Action OnTimerDone, OnSecond;
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private string timerConstText = "TIME LEFT: ";
    [SerializeField] private int maxTime = 40;
    private float timeLeft;
    private float nextSecond;
    private bool isActive;


    void OnEnable()
    {
        OnSecond += UpdateUI;
        OnSecond += CheckForTimerDone;
        OnTimerDone += Stop;
    }
    void OnDisable()
    {
        OnSecond = null;
        OnTimerDone = null;
        //OnTimerDone -= Stop; // This caused an error for some reason.
    }

    void Start()
    {
        timeLeft = maxTime;
        nextSecond = maxTime - 1;
        UpdateUI();
        isActive = true;
    }

    void Update()
    {
        if (!isActive)
            return;

        UpdateTime();
        CheckForSecondPassed();
    }

    private void UpdateTime() => timeLeft -= Time.deltaTime;

    private void CheckForSecondPassed()
    {
        if ((int)timeLeft > nextSecond)
            return;

        nextSecond--;
        OnSecond?.Invoke();
    }

    private void UpdateUI() => tmp.text = $"{timerConstText}{(int)timeLeft + 1}";

    private void CheckForTimerDone()
    {
        if (timeLeft <= 0)
        {
            Stop();
            OnTimerDone?.Invoke();
        }
    }

    public void Stop()     => isActive = false;
    public void Continue() => isActive = true;

}