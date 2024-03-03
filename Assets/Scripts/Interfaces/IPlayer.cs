namespace Interfaces
{
    public interface IPlayer
    {
        void GainEnergy(int energyValue);
        void TakeDamage(int attackValue);
        
        int Energy { get; }

        void ActivateMoldPower();
    }
}