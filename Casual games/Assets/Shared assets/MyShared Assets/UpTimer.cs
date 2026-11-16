using System;
using TMPro;
using UnityEngine;

public class UpTimer : MonoBehaviour
{
    public event Action OnSecond;
    public float Counter {  get; private set; }
    [SerializeField] private TextMeshProUGUI tmp;
    private int pastSecond = 0;
    private bool isActive;


    private void OnEnable()
    {
        OnSecond += UpdateUI;
    }
    private void OnDisable()
    {
        OnSecond -= UpdateUI;
    }

    void Update()
    {
        if (!isActive)
            return;
        UpdateTime();
        CheckForSecond();
    }

    public void StartTimer()
    {
        ResetTime();
        tmp.gameObject.SetActive(true);
        isActive = true;
    }

    public void DisableTimer()
    {
        tmp.gameObject.SetActive(false);
        Stop();
    }

    public void Stop()     => isActive = false;
    public void Continue() => isActive = true;
    private void UpdateTime() => Counter += Time.deltaTime;
    private void UpdateUI() => tmp.text = $"{(int)Counter:D2}";
    private void ResetTime() => Counter = 0;
    private void CheckForSecond()
    {
        if ((int)Counter <= pastSecond)
            return;

        pastSecond++;
        OnSecond?.Invoke();
    }

}