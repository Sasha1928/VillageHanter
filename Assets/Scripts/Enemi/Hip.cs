using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hip : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealf>())
        {
            collision.gameObject.GetComponent<PlayerHealf>().GetDamage(_damage);
        }
    }
}
