using UnityEngine;
using System;
namespace Character.Views
{
    public interface ICharacterView
    {
        SpriteRenderer SpriteRenderer { get; }

        Rigidbody2D Rigidbody2D { get; }

        Transform Transform { get; }

        bool FlipSprite { get; set; }

        Vector2 Direction { get; }

        event Action OnJumpButtonDown;
        int MoveState { set; }
    }
}