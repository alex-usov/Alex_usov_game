using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _normalSpeed;
    private float _oldMousePositionX;
    [SerializeField] Animator _animator;
    private float temp = 0.5f;
    [SerializeField] float _sensivityMove = 2.2f;


    void Start()
    {
        _speed = _normalSpeed;
        _animator.SetFloat("Speed", 1);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartWalk();
            _oldMousePositionX = Input.mousePosition.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            StartRun();
        }
        Move();        
    }
    IEnumerator Walk()
    {
        for (float f = 1f; f >= 0f; f -= 0.2f)
        {
            _animator.SetFloat("Speed", f);
            _speed -= temp;
            yield return new WaitForSeconds(0.01f);

        }
    }
    IEnumerator Run()
    {
        for (float f = 0f; f <= 1f; f += 0.2f)
        {
            _animator.SetFloat("Speed", f);
            _speed += temp;
            yield return new WaitForSeconds(0.01f);
            
        }
    }

    public void StartWalk()
    {
        StartCoroutine("Walk");
    }
    public void StartRun()
    {
        StartCoroutine("Run");
    }

    private void Move()
    {
        Vector3 newPosition = transform.position + transform.forward * Time.deltaTime * _speed;

        if (Input.GetMouseButton(0))
        {
            float deltaX = Input.mousePosition.x - _oldMousePositionX;
            _oldMousePositionX = Input.mousePosition.x;
            
            newPosition.x += deltaX * Time.deltaTime * _sensivityMove / 10;
            newPosition.x = Mathf.Clamp(newPosition.x, -2f, 2f);
        }
        transform.position = newPosition;
    }
}

