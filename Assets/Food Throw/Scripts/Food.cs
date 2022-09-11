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
            Vector3 targetCenter = collision.transform.position;
            Vector3 hitPosition = collision.GetContact(0).point;
            float distanceFromCenter = Vector3.Distance(hitPosition, targetCenter);

            TargetController targetController = collision.transform.GetComponentInParent<TargetController>();
            float targetRadius = targetController.TargetRadius;

            // Closer to center = more points. Clamped so it can't go below 0.
            float distanceFromEdge = Mathf.Max(0, targetRadius - distanceFromCenter);

            Instantiate(_explosionPrefab, transform.position, Random.rotation);
            _gameController.AddScore(distanceFromEdge);
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
