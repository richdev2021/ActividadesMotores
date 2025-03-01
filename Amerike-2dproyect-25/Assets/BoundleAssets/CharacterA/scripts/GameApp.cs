using UnityEngine;
using Character.Controller;
using Character.Models;
using Character.Views;
using DefaultNamespace;
public class GameApp : IGameApp
{
    public void StartApp()
    {
        ICharacterView characterView = GameObject.Find("CharacterBase").GetComponent<CharacterView>();
        ICharacterData characterData = new characterData();

        ICharacterBaseController characterBaseController = new CharacterBaseController(characterView, characterData);
        characterBaseController.StarCharacter();
    }
}
