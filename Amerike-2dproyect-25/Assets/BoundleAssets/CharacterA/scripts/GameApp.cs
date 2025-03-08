using UnityEngine;
using Character.Controller;
using Character.Models;
using Character.Views;
using DefaultNamespace;
using System.Threading;
public class GameApp : IGameApp
{
    private CancellationTokenSource gameToken;

    public GameApp() {
        gameToken = new CancellationTokenSource();
    }
    public void StartApp()
    {
        ICharacterView characterView = GameObject.Find("knight").GetComponent<CharacterView>();
        ICharacterData characterData = new characterData();

        ICharacterBaseController CharacterBaseController = new CharacterBaseController(characterView, characterData, gameToken.Token);
    }
    public void Dispose() {
        gameToken.Cancel();
        gameToken?.Dispose();
        gameToken = null;
    }
}
