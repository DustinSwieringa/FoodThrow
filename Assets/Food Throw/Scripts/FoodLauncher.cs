using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodLauncher : MonoBehaviour
{
    [SerializeField]
    private XRSocketInteractor _ammoSocket;

    [SerializeField]
    private Rigidbody _bulletPrefab;

    [SerializeField]
    private Transform _bulletSpawn;

    [SerializeField]
    private float _bulletSpeed;

    public void Shoot()
    {
        if (!_ammoSocket.hasSelection)
            return;

        Rigidbody bulletCopy = Instantiate(_bulletPrefab, _bulletSpawn.position, Random.rotation);
        bulletCopy.AddForce(_bulletSpawn.forward * _bulletSpeed, ForceMode.Impulse);

        Renderer bulletRenderer = bulletCopy.GetComponentInChildren<Renderer>();
        if (bulletRenderer == null)
            return;

        Food socketFood = _ammoSocket.firstInteractableSelected.transform.GetComponent<Food>();
        if (socketFood == null)
            return;

        bulletRenderer.material.color = socketFood.BulletColor;
    }
}
