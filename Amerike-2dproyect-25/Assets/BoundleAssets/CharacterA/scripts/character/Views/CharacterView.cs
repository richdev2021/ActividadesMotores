using UnityEngine;
using UnityEngine.InputSystem;
using Utils.Bindings;
namespace Character.Views
{
    [RequireComponent(
        requiredComponent: typeof(SpriteRenderer),
        requiredComponent2: typeof(Animator),
        requiredComponent3: typeof(Rigidbody2D)
        )]
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        [SerializeField] private SpriteRenderer spriterenderer;
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private IntBindings movebinding;
        private Vector2 direction;


        public SpriteRenderer SpriteRenderer => spriterenderer;

        public Rigidbody2D Rigidbody2D => rb2d;

        public Transform transform => transform;

        public bool FlipSprite {
            get => spriterenderer.flipX;
            set => spriterenderer.flipX = value;
        }
        public int MoveState { set => movebinding.Value = value; }
        public Vector2 Direction => direction;
        public void JumpButtonDown() { 
        
        }

        public void setDirection(InputAction.CallbackContext ctx) {
            direction = ctx.ReadValue<Vector2>();
        }

    }
}