using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealf : MonoBehaviour
{
    [SerializeField] private int _healf;
    [SerializeField] private Slider _sliderHealf;
    [SerializeField] private LayerMask _layerEnemy;

    [HideInInspector] public bool Block = true;

    private Animator _animator;
    private bool _idleBlock;
    private bool _block = false;
    private MovePlayer _movePlayer;
    private bool _blockButton = false;

    public int Healf => _healf;

    private void Awake()
    {
        _movePlayer = GetComponent<MovePlayer>();
        DontDestroyOnLoad(gameObject);
        _healf = math.clamp(_healf, 0 ,100);
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _sliderHealf.enabled = false;
        _sliderHealf.value = _healf;
        transform.position = new Vector2(7.3f, 2f);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnScaneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnScaneLoaded;
    }

    private void Update()
    {
        if (!_block)
        {
            if (_blockButton)
            {
                _idleBlock = true;
                Block = false;
            }
            else
            {
                _idleBlock = false;
                Block = true;
            }
        }

        _animator.SetBool("IdleBlock", _idleBlock);
    }

    public void GetDamage(int damage)
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), new Vector2(_movePlayer.Direchion, 0), 15f, _layerEnemy);
        if (_idleBlock && hit2D.collider != null)
        {
            _animator.SetTrigger("Block");
            _block = true;
            _idleBlock = false;
        }
        else
        {
            _healf -= damage;
            if (_healf > 0)
                _animator.SetTrigger("Hurt");
            else
            {
                _animator.SetTrigger("Death");
            }
        }
        _sliderHealf.value = _healf;
    }

    private void BlockAnimation()
    {
        _block = false;
    }

    private void OnScaneLoaded(Scene scene,LoadSceneMode mode)
    {
        Transform SpawPoint = GameObject.FindGameObjectWithTag("StartPoint").transform;
        transform.position = SpawPoint.position;
    }

    public void GetPotion(int Healf)
    {
        if (_healf + Healf > 100)
            _healf = 100;
        else
            _healf += Healf;
        _sliderHealf.value = _healf;
    }

    public void ShitButtonDown()
    {
        _blockButton = true;
    }
    public void ShitButtonUp()
    {
        _blockButton = false;
    }

    private void Death()
    {
        SceneManager.LoadScene(1);
        _animator.Play("HeroKnight_Idle");
        _healf = 100;
        _sliderHealf.value = _healf;
    }
}
