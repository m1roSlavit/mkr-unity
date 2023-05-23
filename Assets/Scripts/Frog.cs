using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private GameObject _pivot;

    [SerializeField] private float _power;

    private Rigidbody _rigidbody;

    public bool isGrounded { get; set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(_pivot.transform.position, Vector3.down);

        isGrounded = Physics.Raycast(ray,0.2f, _layerMask);
    }

    public void Jump(Vector3 inputDirection)
    {
        if (isGrounded) 
        { 
            _rigidbody.AddForce(new Vector3(inputDirection.x, 1, inputDirection.z) * _power, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meal"))
        {
            Destroy(other.gameObject);
        }
    }
}
