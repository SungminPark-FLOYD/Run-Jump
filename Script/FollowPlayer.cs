using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    [SerializeField]
    private float speed;
    [SerializeField]
    private  Transform target;    
    
    SpriteRenderer spriter;

    
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        spriter = GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate()
    {
        Vector3 dirVec = target.position - transform.position;
        dirVec.Normalize();

        transform.position += dirVec * speed * Time.fixedDeltaTime;


    }

    private void LateUpdate()
    {
        spriter.flipX = target.position.x > transform.position.x;
    }
}
