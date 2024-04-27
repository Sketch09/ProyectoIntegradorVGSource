using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;  // Rename for clarity and to follow conventions

    void Start()
    {
        // Attempt to find the GameManager when the target is initialized
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);  // Destroy the target
            Destroy(collision.gameObject);  // Destroy the projectile

            // Check if GameManager is properly referenced before calling IncreaseScore
            if (gameManager != null)
            {
                gameManager.IncreaseScore(10);
                gameManager.IncreaseTime(2);// Increase score by 10
            }
            else
            {
                Debug.LogError("GameManager reference not set.");
            }
        }
    }
}
