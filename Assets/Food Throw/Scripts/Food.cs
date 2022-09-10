using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Target"))
        {
            Instantiate(_explosionPrefab, transform.position, Random.rotation);
            // Add score
            Destroy(gameObject);
        }
    }
}
