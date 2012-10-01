using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimudecConsole
{
    class Situation
    {
        // Situation description
        private string mId;
        private string mDescription;
        private int mImage;

        // The simulation owner of this situation
        private Simulation mParentSimulation;

        private List<Option> mOptions;

        public Situation (string _id, string _description){
            mId = _id;
            mDescription = _description;
            
            mOptions = new List<Option>();
        }

        /// <summary>
        /// Methods used in the development mode
        /// </summary>
        public void addOption (Option _option)
        {
            _option.ParentSituation = this;
            mOptions.Add(_option); 
        }

        /// <summary>
        /// Methods used in the player mode
        /// </summary>
        public void selectOption(int _opIndex)
        {
            Utils.showMessage("Options taken: " + mOptions[_opIndex].Description);
            Utils.showMessage("");

            string nextSituation = mOptions[_opIndex].getNextSituation();
            mParentSimulation.setCurrentSituation(nextSituation);
            mParentSimulation.showSituation();
        }

        public int getParamValue(string _paramName)
        {
            return mParentSimulation.getParamValue(_paramName);
        }

        public void showOptions()
        {
            for (int i = 0; i < mOptions.Count; i++)
            {
                Utils.showMessage(mOptions[i].Description);
            }
            //Utils.showMessage("");
        }

        /// <summary>
        /// Properties
        /// </summary>
        public string Id
        {
            get { return mId; }
            set { mId = value; }
        }
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
        internal Simulation ParentSimulation
        {
            get { return mParentSimulation; }
            set { mParentSimulation = value; }
        }
    }
}
