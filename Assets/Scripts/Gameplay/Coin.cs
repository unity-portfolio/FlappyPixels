using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _horSpeed;
    [SerializeField] private float _resetPos;
    [SerializeField] private float _startPos;
    [SerializeField] private BooleanVariable _isPlayerDead;
    [SerializeField] private BooleanVariable _isPlayerActive;
    [SerializeField] private InGameEvent _collectedCoin;
    [SerializeField] private AudioEvent _pickupAudioEvent;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Transform _transform;

    private void Update()
    {
        if(_isPlayerActive.value)
        {
            if (!_isPlayerDead.value)
            {
                Vector3 prevPos = _transform.position;
                prevPos.x -= _horSpeed * Time.deltaTime;
                _transform.position = prevPos;
                if (_transform.position.x <= _resetPos)
                {
                    Vector3 newPos = new Vector3(_startPos, _transform.position.y, _transform.position.z);
                    _transform.position = newPos;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player _player = collision.GetComponent<Player>();

        if(_player)
        {
            _pickupAudioEvent.Play(_audioSource);
            Vector3 newPos = new Vector3(_startPos, _transform.position.y, _transform.position.z);
            _transform.position = newPos;
            _collectedCoin.Raise();
        }
    }
}
