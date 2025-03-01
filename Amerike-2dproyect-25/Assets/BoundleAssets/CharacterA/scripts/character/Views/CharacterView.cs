using UnityEngine;
namespace Character.Views
{
    [RequireComponent(
        requiredComponent: typeof(SpriteRenderer),
        requiredComponent2: typeof(Animator),
        requiredComponent3: typeof(Rigidbody2D)
        )]
    public class CharacterView: MonoBehaviour, ICharacterView
    {
        [SerializeField] private SpriteRenderer spriterenderer;
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rb2d;

        public SpriteRenderer SpriteRenderer => spriterenderer;

        public Animator Animator => animator;

        public Rigidbody2D Rigidbody2D => rb2d;
    }
}