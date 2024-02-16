using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemiLayer;
    [SerializeField] private float _timeToNextAttack;
    [SerializeField] private float _damage;

    private Animator _animator;
    private float _nextAttack;
    private MovePlayer _movePlayer;
    private float _attackRange = 0.4f;
    private PlayerHealf _playerHealf;

    private void Start()
    {
        _nextAttack = _timeToNextAttack;
        _animator = GetComponent<Animator>();
        _movePlayer = GetComponent<MovePlayer>();
        _playerHealf = GetComponent<PlayerHealf>();
    }

    private void Update()
    {
        _nextAttack -= Time.deltaTime;
        //if (Input.GetButtonDown("Fire1") && _nextAttack < 0 && _movePlayer.ChackGround()&& _playerHealf.Block)
        //{
        //    AnimationAttack();
        //    _nextAttack = _timeToNextAttack;
        //}
    }

    private void AnimationAttack()
    {
        int animationAttack = Random.Range(0, 3);
        switch (animationAttack)
        {
            case 0:
                _animator.SetTrigger("Attack1");
                break;
            case 1:
                _animator.SetTrigger("Attack2");
                break;
            case 2:
                _animator.SetTrigger("Attack3");
                break;
        }
    }

    public void AttackButton()
    {
        if ( _nextAttack < 0 && _movePlayer.ChackGround() && _playerHealf.Block)
        {
            AnimationAttack();
            _nextAttack = _timeToNextAttack;
        }
    }

    private void Attack()
    { 
        Collider2D enemi = Physics2D.OverlapCircle(_attackPoint.position, _attackRange, _enemiLayer);
        if (enemi != null && enemi.gameObject.GetComponent<EnemiHealf>())
            enemi.gameObject.GetComponent<EnemiHealf>().GetDamage(_damage);
    }

    public void ChangeWeapon(float Damage)
    {
        _damage = Damage;
    }
}
