using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");  // Replace "GameScene" with the name of your actual game scene.
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");  // Replace "GameScene" with the name of your actual game scene.
    }
}
