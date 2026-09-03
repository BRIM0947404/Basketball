using UnityEngine;
using UnityEngine.XR;

public class Grabber : MonoBehaviour
{
    [SerializeField] private float _grabRadius = 0.15f;
    [SerializeField] private LayerMask _grabbableLayer;
    [SerializeField] private Hand _hand;
    [SerializeField] private VelocityTracker _velocityTracker;

    private Basketball _basketball;

    private void Update()
    {
        if (_basketball == null && _hand.IsGrabbing)
        {
            TryGrab();
        }
        else if(_basketball != null && !_hand.IsGrabbing)
        {
            Release();
        }
    }

    private void TryGrab()
    {
        Collider[] colliders = Physics.OverlapSphere(
            transform.position,
            _grabRadius,
            _grabbableLayer
        );

        foreach (Collider collider in colliders)
        {
            Basketball ball = collider.GetComponentInParent<Basketball>();

            if (ball != null)
            {
                Grab(ball);
                return;
            }
        }
    }

    private void Grab(Basketball ball)
    {
        _basketball = ball;

        ball.Grab(transform);
        _hand.SendHaptic();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _grabRadius);
    }

    private void Release()
    {
        if (_basketball == null)
            return;

        _basketball.Release(_velocityTracker.GetVelocity());

        _basketball = null;
    }


}
