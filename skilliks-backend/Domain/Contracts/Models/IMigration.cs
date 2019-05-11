namespace Domain.Contracts.Models
{
    public interface IMigration
    {
        string Up();
        string Down();
    }
}
