using UnityEngine;
using System;
namespace Character.Models
{
    [Serializable]
    public class characterData : ICharacterData
    {
        [SerializeField]
        private string styleName;
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float jumpforce;
        public float MoveSpeed { get; }
        public float JumpForce { get;  }

        public String StyleName { get; }
        
        //public CharacterData(float moveSpeed, float jumpForce)
        //public float JumpForce { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
