using System;
using UnityEngine;
using Character.Models;
using Character.Views;
using Cysharp.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace Character.Controller {
    public class CharacterBaseController : ICharacterBaseController
    {
        private ICharacterView characterView;
        private ICharacterData characterData;

        private CancellationTokenRegistration cancellationTokenRegistration;

        private float jumpForce;
        private float moveSpeed;
        Rigidbody2D rb2d;
        private Transform transform;

        private static readonly Vector2 jumpDirection = Vector2.up;
        private const ForceMode2D forceMode = ForceMode2D.Impulse;

        public CharacterBaseController(ICharacterView characterView, ICharacterData characterData,
            CancellationToken gametoken)
        {
            this.characterView = characterView;
            this.characterData = characterData;

            characterView.OnJumpButtonDown += Jump;

            jumpForce = characterData.JumpForce;
            moveSpeed = characterData.MoveSpeed;
            
            rb2d = characterView.Rigidbody2D;
            transform = characterView.Transform;

            cancellationTokenRegistration = gametoken.Register(Dispose);
            MovementCicleTask(gametoken).Forget();
        }

        
        private async UniTask MovementCicleTask(CancellationToken gameToken) {
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
        private void Jump() {

            rb2d.AddForce(jumpDirection* jumpForce, forceMode);
        }
        public void Dispose() {
            characterView.OnJumpButtonDown -= Jump;
            cancellationTokenRegistration.Dispose();
        }
    }
}

