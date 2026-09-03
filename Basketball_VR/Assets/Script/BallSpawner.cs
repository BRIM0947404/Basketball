using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Basketball _ballPrefab;

    private bool _canSpawn;

    private void Start()
    {
        _canSpawn = true;
        SpawnBall();
    }

    public void BallTaken()
    {
        _canSpawn = true;
        SpawnBall();
    }

    private void SpawnBall()
    {
        if (!_canSpawn)
            return;

        _canSpawn = false;
        Basketball ball = Instantiate(_ballPrefab, transform.position, transform.rotation);
        ball.SetSpawner(this); // listener instead
    }
}