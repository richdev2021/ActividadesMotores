using Character.Controller;
using Character.Models;
using Character.Views;
using DefaultNamespace;
using System.Threading;
using Utils.AdresableLoader;
using Cysharp.Threading.Tasks;
using DefaultNamespace.Utils.DataApi;
using UnityEditor.U2D.Animation;

public class GameApp : IGameApp
{
    struct CharacterDatabyStyleName
    {
        public string styleName;
    }

    private CancellationTokenSource gameToken;

    public GameApp() {
        gameToken = new CancellationTokenSource();
    }
    public async UniTaskVoid StartApp()
    {
        // ICharacterView characterView = GameObject.Find("knight").GetComponent<CharacterView>();
        var characterView = await AdressableLoader.InstantiateAsync<CharacterView>("basePlayer");

        var getCharacterData = new CharacterDataDummy();
        var getCharacterDataQueryByStyleName = @"query CharacterDataByStyleName(SstyleName: String!){
            StyleName
            moveSpeed
            JumpForce
        }";
        var characterDataByStyleName = new CharacterDatabyStyleName()
        {
            styleName = "knight"
        };
        var fullQueryCharacterData = new GraphQLQuery()
        {
            query = getCharacterDataQueryByStyleName,
            variables = characterDataByStyleName,
        };
        
       /* GraphQLUtils.GetModel<getCharacterData>(fullQueryCharacterData,
            "haracterDataByStyleName",
            gameToken.Token).Forget();
        
        ICharacterData characterData = GraphQLUtils.GetModel<CharacterData>(fullQueryCharacterData,"haracterDataByStyleName",gameToken.Token).Forget();
        ICharacterBaseController CharacterBaseController = new CharacterBaseController(characterView, characterData, gameToken.Token);*/
    }
    public void Dispose() {
        gameToken.Cancel();
        gameToken?.Dispose();
        gameToken = null;
    }
}
