using Character.Controller;
using Character.Models;
using Character.Views;
using DefaultNamespace;
using System.Threading;
using Utils.AdresableLoader;
using Cysharp.Threading.Tasks;
public class GameApp : IGameApp
{
    private CancellationTokenSource gameToken;

    public GameApp() {
        gameToken = new CancellationTokenSource();
    }
    public async UniTaskVoid StartApp()
    {
        // ICharacterView characterView = GameObject.Find("knight").GetComponent<CharacterView>();
        var characterView = await AdressableLoader.InstantiateAsync<CharacterView>("basePlayer");
        ICharacterData characterData = new CharacterDataDummy();

        ICharacterBaseController CharacterBaseController = new CharacterBaseController(characterView, characterData, gameToken.Token);
    }
    public void Dispose() {
        gameToken.Cancel();
        gameToken?.Dispose();
        gameToken = null;
    }
}
