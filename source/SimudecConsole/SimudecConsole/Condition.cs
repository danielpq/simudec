using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimudecConsole
{
    enum Operator { EQUALS, LESS, GREATER };

    class Condition
    {
        // Parameter to be watched, the value and operator will be applied in this parameter
        private string mWatchedParameter;
        // Value to be compared with the current parameter value
        private int mTargetValue;
        private Operator mOperator;

        private Option mParentOption;

        public Condition(string _wParam, int _targetValue, Operator _op)
        {
            mWatchedParameter = _wParam;
            mTargetValue = _targetValue;
            mOperator = _op;
        }

        /// <summary>
        /// Methods used in the player mode
        /// </summary>
        // Based in the operator, checks the satisfiability of the condition
        public bool isSatisfied()
        {
            int paramValue = mParentOption.getParamValue(mWatchedParameter);

            switch (mOperator)
            {
                case Operator.EQUALS:
                    if (paramValue == mTargetValue)
                        return true;
                    break;
                case Operator.LESS:
                    if (paramValue < mTargetValue)
                        return true;
                    break;
                case Operator.GREATER:
                    if (paramValue > mTargetValue)
                        return true;
                    break;
            }
            return false;
        }

        /// <summary>
        /// Properties
        /// </summary>
        internal Option ParentOption
        {
            get { return mParentOption; }
            set { mParentOption = value; }
        }
    }
}
