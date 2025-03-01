using UnityEngine;
using Character.Models;
using Character.Views;
namespace Character.Controller {
    public class CharacterBaseController
    {
        private ICharacterView characterView;
        private ICharacterData characterData;

        public CharacterBaseController(ICharacterView characterView, ICharacterData characterData) {
            this.characterView = characterView;
            this.characterData = characterData;
        }
        public void StarCharacter() { 
        
        }
    }
}

