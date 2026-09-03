using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class Hand : MonoBehaviour
{
    [SerializeField] private XRNode handNode;

    private UnityEngine.XR.InputDevice device;

    public void Update()
    {
        if (!device.isValid)
        {
            device = InputDevices.GetDeviceAtXRNode(handNode);
        }

        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition,out Vector3 position))
        {
            transform.localPosition = position;
        }

        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion rotation))
        {
            transform.localRotation = rotation;
        }

        bool pressed;
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out pressed))
        {
            if (pressed)
            {
                Debug.Log("Grip!");
            }
        }
    }
}
