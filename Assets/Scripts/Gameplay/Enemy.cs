using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject
{
    [SerializeField] private float _vertSpeed;
    [SerializeField] private Vector3 _topPosition;
    [SerializeField] private Vector3 _bottomPosition;
    [SerializeField] private BooleanVariable _isPlayerActive;
    [SerializeField] private Transform _enemyTransform;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveEnemy(_bottomPosition));
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(_isPlayerActive.value)
        {
            base.Update();
        }
    }

    IEnumerator MoveEnemy(Vector3 target)
    {
        while (Mathf.Abs((target - _enemyTransform.position).y) >= .2f)
        {
            Vector3 direction = target.y == _topPosition.y ? Vector3.up : Vector3.down;
            _enemyTransform.position += direction * (_vertSpeed * Time.deltaTime);

            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        Vector3 newTarget = target.y == _topPosition.y ? _bottomPosition : _topPosition;

        StartCoroutine(MoveEnemy(newTarget));
    }
}
