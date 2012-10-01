using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimudecConsole
{
    class Option
    {
        // Situation description
        private string mDescription;

        // Target situation if the conditions were satisfied
        private string mCondSatisTargetSitu;

        // Target situation if the conditions were NOT satisfied
        private string mCondNotSatisTargetSitu;

        // The situation owner of this option
        private Situation mParentSituation;

        // List of conditions. If the list is all satisfied the flow goes to the mCondSatisTargetSitu, else the flow goes to mCondNotSatisTargetSitu
        private List<Condition> mConditions;

        public Option(string _description)
        {
            mDescription = _description;
            mConditions = new List<Condition>();

            mCondSatisTargetSitu = mCondNotSatisTargetSitu = ""; 
            //mParentSituation. get the first situation???
        }

        /// <summary>
        /// Methods used in the development mode
        /// </summary>
        public void addCondition(Condition _condition)
        {
            _condition.ParentOption = this;
            mConditions.Add(_condition);
        }

        /// <summary>
        /// Methods used in the player mode
        /// </summary>
        // The next situation is defined based in the satisfiability of the conditions: if all conditions are satisfied the flow goes to the mCondSatisTargetSitu
        // if only one condition is not satisfied the flow goes to mCondNotSatisTargetSitu
        public string getNextSituation()
        {
            for (int i = 0; i < mConditions.Count; i++)
            {
                if (!mConditions[i].isSatisfied())
                {
                    return mCondNotSatisTargetSitu;
                }
            }
            return mCondSatisTargetSitu;
        }

        public int getParamValue(string _paramName)
        {
            return mParentSituation.getParamValue(_paramName);
        }


        /// <summary>
        /// Properties
        /// </summary>
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        public string CondSatisTargetSitu
        {
            get { return mCondSatisTargetSitu; }
            set { mCondSatisTargetSitu = value; }
        }

        public string CondNotSatisTargetSitu
        {
            get { return mCondNotSatisTargetSitu; }
            set { mCondNotSatisTargetSitu = value; }
        }

        internal Situation ParentSituation
        {
            get { return mParentSituation; }
            set { mParentSituation = value; }
        }

    }
}
