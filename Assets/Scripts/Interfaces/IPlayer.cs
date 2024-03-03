
namespace Interfaces
{
    public interface IPlayer
    {
        void TakeDamage(int attackValue);
        
        float Energy { get; }

        void ActivateMoldPower();

        public UnityEngine.Events.UnityEvent GameOverEvent { get; }
    }
}