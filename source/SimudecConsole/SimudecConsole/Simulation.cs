using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimudecConsole
{
    class Simulation
    {
        // Parameters
        private Dictionary<string, Parameter> mParameters;

        // Simulation description
        private string mDescription;
        private int mImage;

        // Situations controll
        private string mInitialSituation;
        private string mCurrentSituation;
        private Dictionary <string, Situation> mSituations;

        public Simulation()
        {
            mParameters = new Dictionary<string, Parameter>();
            mSituations = new Dictionary<string, Situation>();
        }

        /// <summary>
        /// Methods used in the development mode
        /// </summary>
        public bool addSituation(Situation _situation)
        {
            if (!mSituations.ContainsKey(_situation.Id))
            {
                _situation.ParentSimulation = this;
                mSituations[_situation.Id] = _situation;

                return true;
            }
            else
            {
                Utils.showMessage("[Simulation:addSituation] ERROR: This situation name is already in use, name: " + _situation.Id);
            }
            return false;
        }

        public void removeSituation(string _situationName)
        {
            if (mSituations.ContainsKey(_situationName))
            {
                mSituations.Remove(_situationName);
            }
            else
            {
                Utils.showMessage("[Simulation:removeSituation] WARNING: There is no situation with the name: " + _situationName);
            }
        }

        public bool addParameter(string _paramId, int _initValue = 0)
        {
            if (!mParameters.ContainsKey(_paramId))
            {
                mParameters.Add(_paramId, new Parameter(_paramId, _initValue));
                return true;
            }
            else
            {
                Utils.showMessage("[Simulation:addSituation] ERROR: This parameter name is already in use, name: " + _paramId);
            }
            return false;
        }

        public void removeParameter(string _paramId)
        {
            if (mParameters.ContainsKey(_paramId))
            {
                mParameters.Remove(_paramId);
            }
            else
            {
                Utils.showMessage("[Simulation:removeParameter] WARNING: There is no parameter with the name: " + _paramId);
            }
        }

        /// <summary>
        /// Methods used in the player mode
        /// </summary>
        public void startSimulation()
        {
            mCurrentSituation = mInitialSituation;
        }

        public void showSituation()
        {
            //TODO show the current situation
            Utils.showMessage("Showing the situation: " + mCurrentSituation);
            mSituations[mCurrentSituation].showOptions();
        }

        public void selectOption(int _opIndex)
        {
            mSituations[mCurrentSituation].selectOption(_opIndex);
        }

        public void setCurrentSituation(string _situationId)
        {
            mCurrentSituation = _situationId;
            Utils.showMessage("Current Situation Changed to: " + mCurrentSituation);
        }

        public int getParamValue(string _paramName)
        {
            if (mParameters.ContainsKey(_paramName)){
                return mParameters[_paramName].Value;
            }
            else {
                Utils.showMessage("[Simulation:removeSituation] ERROR: There is no parameter with the name: " + _paramName);
            }
            return 0;
        }

        /// <summary>
        /// Properties
        /// </summary>
        public int Image
        {
            get { return mImage; }
            set { mImage = value; }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        public string InitialSituation
        {
            get { return mInitialSituation; }
            set { mInitialSituation = value; }
        }

        public string CurrentSituation
        {
            get { return mCurrentSituation; }
            set
            {
                mCurrentSituation = value;
                Utils.showMessage("Current Situation Changed to: " + mCurrentSituation);
            }
        }
    }
}
