using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private int _size;
    [SerializeField] private Vector3 _offset;
    [SerializeField] float _padding;

    [SerializeField] private GameObject _leaf;
    [SerializeField] private GameObject _meal;

    private GameObject[,] _leafs;

    private void Start()
    {
        GenerateField();
    }

    private void GenerateField()
    {
        _leafs = new GameObject[_size, _size];

        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                _leafs[i,j] = Instantiate(_leaf);
                _leafs[i, j].transform.position = new Vector3(i* _padding, transform.position.y, j* _padding) - _offset;

                if (Random.Range(0, 10) == 0)
                {
                    GameObject meal = Instantiate(_meal);

                    _leafs[i, j].GetComponent<Leaf>().Meal = meal;
                    meal.transform.position = new Vector3(_leafs[i, j].transform.position.x, _leafs[i, j].transform.position.y + 0.5f, _leafs[i, j].transform.position.z);
                }
            }
        }
    }
}
