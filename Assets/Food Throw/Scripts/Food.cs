using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionPrefab;

    private GameController _gameController;

    public void Initialize(GameController gameController)
    {
        _gameController = gameController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Target"))
        {
            Instantiate(_explosionPrefab, transform.position, Random.rotation);
            _gameController.AddScore();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            Instantiate(_explosionPrefab, transform.position, Random.rotation);
            Destroy(gameObject);
        }
    }
}
