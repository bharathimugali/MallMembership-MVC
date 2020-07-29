using MallMemebership.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MallMembership.BusinessLayer
{
    public class StageBusiness : IStageBusiness
    {
        private readonly StageDL getStageDL = new StageDL();
        public int GetCompletedStage(int id)
        {
            try
            {
                int highestCompletedStage = getStageDL.GetCompleteStage(id);
                return highestCompletedStage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateCompleteStage(int id, int stage)
        {
            try
            {
                getStageDL.UpdateCompleteStage(id, stage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
