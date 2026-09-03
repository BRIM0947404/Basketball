using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _score = 0;

    public void AddPoint()
    {
        _score++;
        Debug.Log($"Score: {_score}");
    }
}
