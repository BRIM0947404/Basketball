using UnityEngine;
using UnityEngine.SceneManagement;

public class HoopDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _ballLayer;
    [SerializeField] private GameManager _gameManager;


    private void OnTriggerEnter(Collider other)
    {
        if ((_ballLayer.value & (1 << other.gameObject.layer)) == 0)
            return;

        Basketball ball = other.GetComponentInParent<Basketball>();

        if (ball == null)
            return;

        if (ball.GetVerticalVelocity() < 0)
        {
            _gameManager.AddPoint();
        }
    }
}
