namespace MallMemebership.DataLayer
{
    public interface IStageDL
    {
        int GetCompleteStage(int id);
        void UpdateCompleteStage(int id, int stage);
    }
}