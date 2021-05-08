using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class PowerUp 
{
    [SerializeField]
    public string _name;

    [SerializeField]
    public int _type;

    [SerializeField]
    public float _dropChance;

    [SerializeField]
    public float _duration;

    [SerializeField]
    public Sprite _sprite;

    [SerializeField]
    public UnityEvent _startAction;

    [SerializeField]
    public UnityEvent _endAction;

    [SerializeField]
    public UnityEvent _dropAction;

    public void Start()
    {
        if (_startAction != null)
        {
            _startAction.Invoke();
        }
    }

    public void End()
    {
        if(_endAction != null)
        {
            _endAction.Invoke();
        }
    }

    public void Drop()
    {
        if (_dropAction != null)
        {
            _dropAction.Invoke();
        }
    }

}
