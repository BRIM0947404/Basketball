using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Hand _leftHand;
    [SerializeField] private Hand _rightHand;

    private int _score = 0;

    public void AddPoint()
    {
        _score++;
        _leftHand.UpdateScore(_score);
        _rightHand.UpdateScore(_score);
        Debug.Log($"Score: {_score}");
    }
}
