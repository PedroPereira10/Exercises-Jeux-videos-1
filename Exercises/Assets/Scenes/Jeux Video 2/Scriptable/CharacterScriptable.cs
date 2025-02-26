using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObject/Character", order = 1)]

public class CharacterScriptable : ScriptableObject
{
    public Sprite _sprite;
    public int _hitPoint;
    public int _damage;
    public Vector3 _position;
}
