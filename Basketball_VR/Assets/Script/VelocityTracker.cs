using System.Collections.Generic;
using UnityEngine;

public class VelocityTracker : MonoBehaviour
{
    [SerializeField] private int _frameCount = 5;
    [SerializeField] private float _multiplier = 1;
    private List<Vector3> _positions = new List<Vector3>();


    // Update is called once per frame
    void Update()
    {
        _positions.Add(transform.position);

        if (_positions.Count > _frameCount)
        {
            _positions.RemoveAt(0);
        }
    }

    public Vector3 GetVelocity()
    {
        if (_positions.Count < 2)
            return Vector3.zero;

        Vector3 velocity = Vector3.zero;

        for (int i = 1; i < _positions.Count; i++)
        {
            velocity += ( _positions[i] -  _positions[i - 1]) / Time.deltaTime;
        }
            
        return velocity / (_positions.Count - 1) * _multiplier;
    }
}
