using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Hand _leftHand;
    [SerializeField] private Hand _rightHand;


    public void UpdateScore(int currentScore)
    {
        _rightHand.UpdateScore(currentScore);
        _leftHand.UpdateScore(currentScore);
    }
}
