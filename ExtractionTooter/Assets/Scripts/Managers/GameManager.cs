using System;
using Cysharp.Threading.Tasks.Triggers;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private string mainMenuScene;
    [SerializeField] private string gameScene;

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(mainMenuScene);
        InventoryManager.singleton.Reset();
    }
}
