using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;

    private int _score = 0;

    public void AddPoint()
    {
        _score++;
        _playerManager.UpdateScore(_score);
    }
}
