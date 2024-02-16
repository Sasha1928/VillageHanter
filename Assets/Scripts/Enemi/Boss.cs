using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _attackDistans;
    [SerializeField] private float _timeInNextAttack;

    private PlayerHealf _player;
    private bool _rotate = true;
    private Animator _animator;
    private float _nextAttack;

    private float _distans;

    private void Start()
    {
        _nextAttack = _timeInNextAttack;
        _player = FindAnyObjectByType<PlayerHealf>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _nextAttack -= Time.deltaTime;
        _distans = Vector3.Distance(transform.position, _player.transform.position);
        if (_distans > _attackDistans)
        {
            RunInPlayer();
        }
        else if (_nextAttack < 0)
        {
            AttackAnimation();
            _nextAttack = _timeInNextAttack;
        }
        else
            _animator.SetTrigger("Idle");
    }

    private void RunInPlayer()
    {
        _animator.SetTrigger("Walk");
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);

        if (transform.position.x > _player.transform.position.x && !_rotate)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            _rotate = true;
        }

        else if (transform.position.x < _player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            _rotate = false;
        }
    }

    private void AttackAnimation()
    {
        switch (Random.Range(0,4)) 
        {
            case 0:
                _animator.SetTrigger("Attack0");
                break;
            case 1:
                _animator.SetTrigger("Attack1");
                break;
            case 2:
                _animator.SetTrigger("Attack2");
                break;
            case 3:
                _animator.SetTrigger("DeathTP");
                break;
        }
    }

    private void AttackPlayer(int Damage)
    {
        _player.GetDamage(Damage);
    }

    private void Teleport()
    {
        if (_player.transform.position.x < transform.position.x)
            transform.position += new Vector3(-4, 0, 0);
        else
            transform.position += new Vector3(4, 0, 0);
    }
}
