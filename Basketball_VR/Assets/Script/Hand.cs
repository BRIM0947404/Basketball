using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class Hand : MonoBehaviour
{
    [SerializeField] private XRNode _handNode;

    private bool _isGRabbing;

    public bool IsGrabbing => _isGRabbing;

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
           _isGRabbing = pressed;
        }
    }

    public void SendHaptic()
    {
        if (!_device.isValid)
            return;

        _device.SendHapticImpulse(0, 0.5f, 0.08f);
    }
}
