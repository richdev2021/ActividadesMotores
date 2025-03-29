using UnityEngine;
namespace Character.Models {
    public class CharacterDataDummy : ICharacterData
    {
        public float MoveSpeed => 3f;
        public float JumpForce => 2f;

        public string StyleName => "knight";
    }
}

