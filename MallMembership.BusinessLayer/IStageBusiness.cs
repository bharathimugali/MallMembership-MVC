namespace MallMembership.BusinessLayer
{
    public interface IStageBusiness
    {
        int GetCompletedStage(int id);
        void UpdateCompleteStage(int id, int stage);
    }
}