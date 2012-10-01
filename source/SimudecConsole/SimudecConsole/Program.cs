using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimudecConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // **** CREATEs THE SIMULATION ****
            Simulation testSimulation = new Simulation();
            // Add Parameters
            string [] parameters = {"param1", "param2", "param3"};
            testSimulation.addParameter(parameters[0], 10);
            testSimulation.addParameter(parameters[1]);
            testSimulation.addParameter(parameters[2]);

            // Situations
            Situation sit1 = new Situation("sit1", "desc situation 1");
            Situation sit2 = new Situation("sit2", "desc situation 2");
            Situation sit3 = new Situation("sit3", "desc situation 3");
            testSimulation.addSituation(sit1);
            testSimulation.addSituation(sit2); 
            testSimulation.addSituation(sit3);
            testSimulation.InitialSituation = sit1.Id; //  Sets the initial situation

            // Options sit1
            Option op1 = new Option("Desc option 1");
            op1.CondSatisTargetSitu = sit2.Id;
            op1.CondNotSatisTargetSitu = sit3.Id;
            op1.addCondition(new Condition(parameters[0], 10, Operator.EQUALS));
            op1.addCondition(new Condition(parameters[1], 10, Operator.LESS));

            Option op2 = new Option("Desc option 2");
            op2.CondSatisTargetSitu = sit1.Id;
            op2.CondNotSatisTargetSitu = sit3.Id;
            op2.addCondition(new Condition(parameters[2], 0, Operator.EQUALS));
            sit1.addOption(op1);
            sit1.addOption(op2);

            // Options sit2
            op1 = new Option("Desc option 1");
            op1.CondSatisTargetSitu = sit2.Id;
            op1.CondNotSatisTargetSitu = sit3.Id;
            op1.addCondition(new Condition(parameters[0], 10, Operator.EQUALS));

            op2 = new Option("Desc option 2");
            op2.CondSatisTargetSitu = sit1.Id;
            op2.CondNotSatisTargetSitu = sit3.Id;
            op2.addCondition(new Condition(parameters[2], 10, Operator.EQUALS));
            sit2.addOption(op1);
            sit2.addOption(op2);

            // Options sit3
            op1 = new Option("Desc option 1");
            op1.CondSatisTargetSitu = sit2.Id;
            op1.CondNotSatisTargetSitu = sit3.Id;
            op1.addCondition(new Condition(parameters[0], 10, Operator.EQUALS));
            op1.addCondition(new Condition(parameters[1], 10, Operator.LESS));

            op2 = new Option("Desc option 2");
            op2.CondSatisTargetSitu = sit1.Id;
            op2.CondNotSatisTargetSitu = sit3.Id;
            op2.addCondition(new Condition(parameters[2], 0, Operator.EQUALS));
            sit3.addOption(op1);
            sit3.addOption(op2);


            // **** PLAYS THE SIMULATION ****
            testSimulation.startSimulation();
            testSimulation.showSituation();
            testSimulation.selectOption(0);
            testSimulation.selectOption(1);


            Console.ReadLine();
        }
    }
}
