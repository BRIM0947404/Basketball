using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class Hand : MonoBehaviour
{
    [SerializeField] private XRNode _handNode;
    [SerializeField] private TMP_Text _scoreText;
    
    public bool IsGrabbing { get; private set; }

    private UnityEngine.XR.InputDevice _device;

    public void Update()
    {
        if (!_device.isValid)
        {
            _device = InputDevices.GetDeviceAtXRNode(_handNode);
        }

        if (_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition,out Vector3 position))
        {
            transform.localPosition = position;
        }

        if (_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion rotation))
        {
            transform.localRotation = rotation;
        }

        if (_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool pressed))
        {
           IsGrabbing = pressed;
        }
    }

    public void SendGrabBallHaptic()
    {
        SendHaptic(0.5f, 0.08f);
    }
    
    public void SendPointHaptic()
    {
        SendHaptic(0.75f, 1f);
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
