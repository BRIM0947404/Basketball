using UnityEngine;

[CreateAssetMenu(fileName = "HandScriptableObject", menuName = "Scriptable Objects/HandScriptableObject")]
public class HandScriptableObject : ScriptableObject
{
    [SerializeField] private float _hapticGrabIntensity = 0.5f;
    [SerializeField] private float _hapticGrabDuration = 0.08f;
    [SerializeField] private float _hapticScoreIntensity = 0.75f;
    [SerializeField] private float _hapticScoreDuration = 1f;
    [SerializeField] private int _velocityframeCount = 10;
    [SerializeField] private float _multiplier = 1.5f;

    public float HapticGrabIntensity => _hapticGrabIntensity;
    public float HapticGrabDuration => _hapticGrabDuration;
    public float HapticScoreIntensity => _hapticScoreIntensity;
    public float HapticScoreDuration => _hapticScoreDuration;
    public int VelocityFrameCount => _velocityframeCount;
    public float Multiplier => _multiplier;
}
