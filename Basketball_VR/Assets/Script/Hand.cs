using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class Hand : MonoBehaviour
{
    [SerializeField] private XRNode _handNode;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private HandScriptableObject _handScriptableObject;
    
    public bool IsGrabbing { get; private set; }

    private InputDevice _device;

    public void Update()
    {
        if (!_device.isValid)
        {
            _device = InputDevices.GetDeviceAtXRNode(_handNode);
        }

        if (_device.TryGetFeatureValue(CommonUsages.devicePosition,out Vector3 position))
        {
            transform.localPosition = position;
        }

        if (_device.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation))
        {
            transform.localRotation = rotation;
        }

        if (_device.TryGetFeatureValue(CommonUsages.gripButton, out bool pressed))
        {
           IsGrabbing = pressed;
        }
    }

    public void SendGrabBallHaptic()
    {
        SendHaptic(_handScriptableObject.HapticGrabIntensity, _handScriptableObject.HapticGrabDuration);
    }
    
    public void SendPointHaptic()
    {
        SendHaptic(_handScriptableObject.HapticScoreIntensity, _handScriptableObject.HapticScoreDuration);
    }

    public void SendHaptic(float amplitude, float duration)
    {
        if (!_device.isValid)
            return;

        _device.SendHapticImpulse(0, amplitude, duration);
    }

    public void UpdateScore(int currentScore)
    {
        SendPointHaptic();
        _scoreText.text = $"Score: {currentScore}";
    }
}
