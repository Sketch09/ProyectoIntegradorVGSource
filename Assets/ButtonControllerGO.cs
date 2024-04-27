using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControllerGO : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");  // Replace "GameScene" with the name of your actual game scene.
    }
}
