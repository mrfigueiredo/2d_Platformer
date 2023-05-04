using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public Player playerReference;
    public PauseManager pauseManager;
    public GameObject victoryPanel;
    public VictoryPanelUI victoryUI;
    public GameObject defeatPanel;


    private void OnEnable()
    {
        playerReference.OnDeathEvent += PlayerDeath;
    }

    private void OnDisable()
    {
        playerReference.OnDeathEvent -= PlayerDeath;
    }

    protected override void Awake()
    {
        base.Awake();
        pauseManager.UnPause();
        playerReference.OnDeathEvent += PlayerDeath;
    }

    private void PlayerDeath(int i)
    {
        defeatPanel.SetActive(true);
        pauseManager.Pause();
    }

    public void PlayerWin()
    {
        victoryUI.CompleteUI();
        victoryPanel.SetActive(true);
        pauseManager.Pause();
    }
}
