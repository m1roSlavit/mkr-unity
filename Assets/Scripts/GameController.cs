using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Frog _frog;

    private Field _field;

    private Vector2 _inputDirection;


    private void Start()
    {
        _field = GetComponent<Field>();
    }

    private void Update()
    {
        _inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        _frog.transform.forward = Vector3.Lerp(_frog.transform.forward, new Vector3(_inputDirection.x,0, _inputDirection.y), Time.fixedDeltaTime);

        Debug.DrawRay(_frog.transform.position, _frog.transform.forward, Color.red);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _frog.Jump(_frog.transform.forward);
        }
    }
}
