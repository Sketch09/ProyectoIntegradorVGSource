using System.Collections;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public float spawnRate = 3f;  // Updated to spawn every 5 seconds as per your request
    public GameObject boundsObject; // GameObject with the BoxCollider2D that defines movement bounds

    public float moveSpeed = 2f;  // Speed at which the spawner moves

    private Vector2 spawnMin;
    private Vector2 spawnMax;
    private Vector2 moveMin;  // Minimum boundary for movement
    private Vector2 moveMax;  // Maximum boundary for movement

    private BoxCollider2D boundsCollider;  // Collider to define movement bounds

    private void Start()
    {
        // Initialize movement and spawning bounds from the boundsObject's BoxCollider2D
        InitializeBounds();
        StartCoroutine(SpawnTargets());
        StartCoroutine(MoveSpawner());
    }

    private void InitializeBounds()
    {
        // Get the BoxCollider2D from the boundsObject
        boundsCollider = boundsObject.GetComponent<BoxCollider2D>();
        if (boundsCollider != null)
        {
            moveMin = boundsCollider.bounds.min;
            moveMax = boundsCollider.bounds.max;
            spawnMin = moveMin; // Optionally set spawn bounds equal to movement bounds
            spawnMax = moveMax;
        }
        else
        {
            Debug.LogError("Boundary GameObject does not have a BoxCollider2D component.");
        }
    }

    IEnumerator SpawnTargets()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            float x = Random.Range(spawnMin.x, spawnMax.x);
            float y = Random.Range(spawnMin.y, spawnMax.y);
            Instantiate(targetPrefab, new Vector2(x, y), Quaternion.identity);
        }
    }

    IEnumerator MoveSpawner()
    {
        Vector2 newPosition = new Vector2();

        while (true)
        {
            // Randomize the next position within defined bounds
            newPosition.x = Random.Range(moveMin.x, moveMax.x);
            newPosition.y = Random.Range(moveMin.y, moveMax.y);

            // Move towards the new position
            while ((Vector2)transform.position != newPosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // Wait a bit before moving to the next random position
            yield return new WaitForSeconds(1f);
        }
    }
}
