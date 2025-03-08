using UnityEngine;
namespace Character.Models
{
    public class characterData : ICharacterData
    {
        public float MoveSpeed { get; set; }
        public float JumpForce { get; set; }
        //public float JumpForce { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
