using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStatic : MonoBehaviour
{
    [SerializeField] private Vector3 _vector;

    private Quaternion _quaternion;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _quaternion = transform.rotation;
    }


    private void LateUpdate()
    {
        transform.rotation = _quaternion;
        transform.position = _player.transform.position + _vector /*new Vector3(1.22f, 2.67f, -10f)*/;
    }

}
