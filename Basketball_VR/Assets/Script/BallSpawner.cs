using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Basketball _ballPrefab;

    private Basketball _currentBall;

    void Start()
    {
        _currentBall = null;
        SpawnBall();
    }

    public void BallGrabbed()
    {
        _currentBall.OnBallGrabbed -= BallGrabbed;
        _currentBall = null;
        SpawnBall();
    }

    private void SpawnBall()
    {
        if (_currentBall != null)
            return;
        _currentBall = Instantiate(_ballPrefab, transform.position, transform.rotation);
        _currentBall.OnBallGrabbed += BallGrabbed;

    }
}