using System;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float _horSpeed;
    [SerializeField] private float _resetPos;
    [SerializeField] private float _startPos;
    [SerializeField] private BooleanVariable _isPlayerDead;
    [SerializeField] private Transform _transform;
    

    // Update is called once per frame
    virtual protected void Update()
    {
        if(!_isPlayerDead.value)
        {
            Vector3 prevPos = _transform.position;
            prevPos.x -= _horSpeed * Time.deltaTime;
            _transform.position = prevPos;
            if(_transform.position.x <= _resetPos)
            {
                Vector3 newPos = new Vector3(_startPos, _transform.position.y, _transform.position.z);
                _transform.position = newPos;
            }
        }
    }
}
