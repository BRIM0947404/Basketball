using UnityEngine;


public class Basketball : MonoBehaviour
{
    [SerializeField]private Rigidbody _rb; // TODO check if not null

    public void Grab(Transform hand)
    {
        _rb.isKinematic = true;
        _rb.detectCollisions = false;

        transform.SetParent(hand, false);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    public void Release()
    {
        transform.SetParent(null);

        _rb.isKinematic = false;
        _rb.detectCollisions = true;
        _rb.useGravity = true;
    }
}
