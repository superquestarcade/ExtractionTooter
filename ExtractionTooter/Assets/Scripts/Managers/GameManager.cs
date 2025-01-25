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
        
    }
}
