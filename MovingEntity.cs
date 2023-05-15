using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(MovementTransform2D))]
public class MovingEntity : MonoBehaviour
{
    private MovementTransform2D movement2D;
    private Vector3 originPosition;
    private Vector3 originDirection;

    private void Awake()
    {
        movement2D = GetComponent<MovementTransform2D>();
        originPosition = transform.position;
        originDirection = movement2D.MoveDirection;
    }

    public void Reset()
    {
        //이동방향과 위치 초기화
        movement2D.MoveTo(originDirection);
        transform.position = originPosition;
    }
}
