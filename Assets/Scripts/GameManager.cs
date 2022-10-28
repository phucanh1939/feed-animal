using System;
using GG.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Events Listen to")]
    [SerializeField] private VoidEventChannelSO _onPlayerDead;

    [Header("UI")]
    [SerializeField] private GameObject _gameOverPopup;

    private void Start()
    {
        HideGameOverPopup();
    }

    private void OnEnable()
    {
        _onPlayerDead.onEventRaised += OnPlayerDead;
    }

    private void OnDisable()
    {
        _onPlayerDead.onEventRaised -= OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        GameOver();
    }

    public void GameOver()
    {
        Pause();
        ShowGameOverPopup();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    // ReSharper disable once UnusedMember.Global
    public void OnButtonPlayAgainPressed()
    {
        HideGameOverPopup();
        Resume();
        Restart();
    }

    public void HideGameOverPopup() => _gameOverPopup.SetActive(false);

    public void ShowGameOverPopup() => _gameOverPopup.SetActive(true);
}
