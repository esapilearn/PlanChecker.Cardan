using ESAPIX.Constraints;
using System;
using VMS.TPS.Common.Model.API;

namespace ESAPX_StarterUI.ViewModels
{
    public class CTDateConstraint : IConstraint
    {
        public string Name => "CT Date < 60 days old";

        public string FullName => "CT Date < 60 days old";

        public ConstraintResult CanConstrain(PlanningItem pi)
        {
            var hasCT = pi.StructureSet?.Image != null;
            if (hasCT) { return new ConstraintResult(this, ResultType.PASSED, string.Empty); }
            else { return new ConstraintResult(this, ResultType.NOT_APPLICABLE, string.Empty); }
        }

        /// <summary>
        /// Check if CT date is older than 60 days
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public ConstraintResult Constrain(PlanningItem pi)
        {
            var ctDate = pi.StructureSet.Image.CreationDateTime.Value;
            return ConstrainDateOnly(ctDate);
        }

        public ConstraintResult ConstrainDateOnly(DateTime ctDate)
        {
            var daysOld = (DateTime.Now - ctDate).TotalDays;
            var msg = $"CT is {daysOld} days old";

            if (daysOld > 60)
            {
                return new ConstraintResult(this, ResultType.ACTION_LEVEL_3, msg);
            }
            else
            {
                return new ConstraintResult(this, ResultType.PASSED, msg);
            }
        }
    }
}