using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PatrulAndAttack : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _distanseToPlayer;
    [SerializeField] private float _attackDistans;
    [SerializeField] private float _timeToAttack;
    [SerializeField] private int _damage;

    private PlayerHealf _player;
    private int _nextPoint;
    private Animator _animator;
    private float _nextAttack;
    private bool _rotate = true;
    private Transform pointInRun;

    private void Start()
    {
        _nextAttack = _timeToAttack;
        _player = GameObject.FindObjectOfType<PlayerHealf>();
        _animator = GetComponent<Animator>();
        _nextPoint = Random.Range(0, _points.Length);
    }

    void Update()
    {
        float Distans = Vector2.Distance(transform.position, _player.gameObject.transform.position);

        _nextAttack -= Time.deltaTime;

        if (Distans <= _attackDistans ) {
            if (_nextAttack < 0)
            {
                Attack();
                _nextAttack = _timeToAttack;
              //  AttackPLayer();
            }
            else
                _animator.SetTrigger("Idle");
        }
        else
            Patrol(Distans);
        
    }

    private void Patrol(float Distans)
    {
        _animator.SetTrigger("Run");
        if (Vector2.Distance(transform.position, _points[_nextPoint].position) < 0.3f)
            _nextPoint = Random.Range(0, _points.Length);

        pointInRun = _points[_nextPoint];

        if (Distans < _distanseToPlayer)
            pointInRun = _player.gameObject.transform;

        transform.position = Vector2.MoveTowards(transform.position, pointInRun.position, _speed * Time.deltaTime);

        if (transform.position.x > pointInRun.position.x && !_rotate)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            _rotate = true;
        }

        else if (transform.position.x < pointInRun.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            _rotate = false;
        }
    }

    private void Attack()
    {
        int anumAttack = Random.Range(0, 2);
        switch (anumAttack)
        {
            case 0:
                _animator.SetTrigger("Attack1");
                break;
            case 1:
                _animator.SetTrigger("Attack2");
                break;
        }
    }

    private void AttackPLayer()
    {
        _player.GetDamage(_damage);
    }
}