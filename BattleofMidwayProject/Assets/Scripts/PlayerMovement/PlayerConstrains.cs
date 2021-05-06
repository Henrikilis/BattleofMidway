using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConstrains : MonoBehaviour
{
    public Camera _MainCamera;
    private Vector2 _screenBounds;
    private float _objectWidth;
    private float _objectHeight;

    // Use this for initialization
    void Start()
    {
        _MainCamera = Camera.main;
        _screenBounds = _MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _MainCamera.transform.position.z));
        _objectWidth = transform.GetComponentInChildren<SpriteRenderer>().bounds.extents.x; 
        _objectHeight = transform.GetComponentInChildren<SpriteRenderer>().bounds.extents.y; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 _viewPos = transform.position;
        _viewPos.x = Mathf.Clamp(_viewPos.x, _screenBounds.x * -1 + _objectWidth, _screenBounds.x - _objectWidth);
        _viewPos.y = Mathf.Clamp(_viewPos.y, _screenBounds.y * -1 + _objectHeight, _screenBounds.y - _objectHeight);
        transform.position = _viewPos;
    }
}
