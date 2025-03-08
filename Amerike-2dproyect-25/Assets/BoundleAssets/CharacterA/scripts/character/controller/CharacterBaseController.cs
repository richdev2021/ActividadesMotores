using UnityEngine;
using Character.Models;
using Character.Views;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Character.Controller {
    public class CharacterBaseController : ICharacterBaseController
    {
        private ICharacterView characterView;
        private ICharacterData characterData;
        private CancellationTokenRegistration cancellationTokenRegistration;
        public CharacterBaseController(ICharacterView characterView, ICharacterData characterData,CancellationToken gametoken) {
            this.characterView = characterView;
            this.characterData = characterData;
            cancellationTokenRegistration = gametoken.Register(Dispose);
            MovementCicleTask(gametoken).Forget();
        }
        
        private async UniTask MovementCicleTask(CancellationToken gameToken) {
            var transform = characterView.transform;

            var moveSpeed = 3f;
            while (!gameToken.IsCancellationRequested) {
                var direction = characterView.Direction;
                var horizontal = direction.x;

                var flipX = characterView.FlipSprite;
                flipX = horizontal < 0 ? true : !(horizontal > 0) && flipX;
                characterView.FlipSprite = flipX;
                characterView.MoveState = Mathf.Abs((int)horizontal);

                transform.Translate(direction * moveSpeed*Time.deltaTime);
                await UniTask.NextFrame();
            }
        }
        public void Dispose() {
            cancellationTokenRegistration.Dispose();
        }
    }
}

