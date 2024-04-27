using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundaryCollision : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
