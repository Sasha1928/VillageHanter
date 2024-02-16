using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _player;
    private MovePlayer _movePlayer;
    private RawImage _image;
    private float posihonX = 0;

    private void Start()
    {
        _image = GetComponent<RawImage>();
        _movePlayer = GameObject.FindAnyObjectByType<MovePlayer>();
        _player = _movePlayer.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        posihonX += _speed * _movePlayer.DirX * Time.deltaTime;

        if (posihonX > 1)
            posihonX = 0;

        _image.uvRect = new Rect(posihonX, 0, _image.uvRect.width, _image.uvRect.height);
    }
}
