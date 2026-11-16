using UnityEngine;
using System;

public class Pause : MonoBehaviour
{
    public event Action OnPause, OnUnpause;
    [HideInInspector] public bool isActive;
    public bool IsPaused { get; private set; }
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private bool pauseWithBackButton = true;
    [SerializeField] private bool pauseWithTimescale = true;
    private bool hasPauseMenu;

    void OnEnable()
    {
        OnPause += DoPause;
        OnUnpause += DoUnpause;
    }
    void OnDisable()
    {
        OnPause -= DoPause;
        OnUnpause -= DoUnpause;

        if (pauseWithTimescale)
            Time.timeScale = 1.0f;
    }

    void Start()
    {
        hasPauseMenu = pauseMenu != null;
    }

    void Update()
    {
        if (pauseWithBackButton)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                PauseGame();
        }
    }

    public void PauseGame()
    {
        if (IsPaused || !isActive)
            return;
        OnPause?.Invoke();
    }

    public void UnpauseGame()
    {
        if (!IsPaused || !isActive)
            return;
        OnUnpause?.Invoke();
    }

    private void DoPause()
    {
        IsPaused = true;
        if (pauseWithTimescale)
            Time.timeScale = 0f;
        if(hasPauseMenu)
            pauseMenu.SetActive(true);
    }

    private void DoUnpause()
    {
        IsPaused = false;
        if (pauseWithTimescale)
            Time.timeScale = 1.0f;
        if (hasPauseMenu)
            pauseMenu.SetActive(false);
    }

    // Pause game when we are not looking at the screen
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            PauseGame();
    }
}
