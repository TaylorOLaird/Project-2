namespace Interfaces
{
    public interface IEnemy : IGrabbable
    {
        // returns enemy remaining health
        int TakeDamage(int dmg);

        void Mold();
    }
}