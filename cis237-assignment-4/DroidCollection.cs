using System;
using System.Collections.Generic;
using System.Text;

namespace cis237_assignment_4
{
    class DroidCollection : IDroidCollection
    {
        // Private variable to hold the collection of droids
        private IDroid[] droidCollection;
        // Private variable to hold the length of the Collection
        private int lengthOfCollection;

        // Constructor that takes in the size of the collection.
        // It sets the size of the internal array that will be used.
        // It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            // Make new array for the collection
            droidCollection = new IDroid[sizeOfCollection];

            droidCollection[0] = new ProtocolDroid("Carbonite", "White", 2);
            droidCollection[1] = new AstromechDroid("Vanadium", "Red", true, true, true, true, 4);
            droidCollection[2] = new JanitorDroid("Quadranium", "Blue", true, false, false, true, true);
            droidCollection[3] = new UtilityDroid("Tears Of A Jedi", "Green", false, true, true);
            droidCollection[4] = new ProtocolDroid("Quadranium", "Red", 6);
            droidCollection[5] = new AstromechDroid("Tears Of A Jedi", "White", false, false, false, false, 9);
            droidCollection[6] = new JanitorDroid("Carbonite", "Green", false, true, true, false, false);
            droidCollection[7] = new UtilityDroid("Vanadium", "Blue", true, false, false);

            // Set length of collection to 0
            lengthOfCollection = 0;
        }

        // The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Color, int NumberOfLanguages)
        {
            // If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                // Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                // of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Color, NumberOfLanguages);
                // Increase the length of the collection
                lengthOfCollection++;
                // return that it was successful
                return true;
            }
            // Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        // The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        // The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The last method that must be implemented due to implementing the interface.
        // This method iterates through the list of droids and creates a printable string that could
        // be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            // Declare the return string
            string returnString = "";

            // For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                // If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    // Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    // the program will automatically know which version of CalculateTotalCost it needs to call based
                    // on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    // Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            // return the completed string
            return returnString;
        }
        /// <summary>
        /// Categorizes the list based on the Jawa's specifications. Astromech, Janitor, Utility, Protocol. 
        /// Loops through the array and checks each droids type, adding them to their respective stack, keeps a running count of each type.
        /// Adds all the counts together to have a total count for dequeuing.
        /// Uses that count of each type to enqueue each stack in the Jawa's order.
        /// Dequeues the Queue by looping until total count reaches 0. Assigns the queue to the array in the categorized order for output.
        /// </summary>
        public void CategorizeList()
        {
            //queue and stack instances
            GenericQueue<IDroid> droidQueue = new GenericQueue<IDroid>();
            GenericStack<AstromechDroid> astroStack = new GenericStack<AstromechDroid>();
            GenericStack<JanitorDroid> janiStack = new GenericStack<JanitorDroid>();
            GenericStack<UtilityDroid> utilityStack = new GenericStack<UtilityDroid>();
            GenericStack<ProtocolDroid> protocolStack = new GenericStack<ProtocolDroid>();

            //counters
            int aCount = 0;
            int jCount = 0;
            int uCount = 0;
            int pCount = 0;

            //Load the stacks
            foreach (IDroid droid in droidCollection)
            {
                if (droid != null)
                {
                    if (droid is AstromechDroid)
                    {
                        IDroid d = droid as AstromechDroid;
                        astroStack.Push((AstromechDroid)d);
                        aCount++;
                        
                    }
                    if (droid is JanitorDroid)
                    {
                        IDroid d = droid as JanitorDroid;
                        janiStack.Push((JanitorDroid)d);
                        jCount++;
                    }
                    if (droid.GetType() == typeof(UtilityDroid))
                    {
                        IDroid d = droid as UtilityDroid;
                        utilityStack.Push((UtilityDroid)d);
                        uCount++;
                    }
                    if (droid is ProtocolDroid)
                    {
                        IDroid d = droid as ProtocolDroid;
                        protocolStack.Push((ProtocolDroid)d);
                        pCount++;
                    }
                }
            }
            //counter for dequeue
            int totalCount = aCount + jCount + uCount + pCount;
            //while there are still astromechs in the stack, load the queue
            while(aCount > 0)
            {
                droidQueue.Enqueue(astroStack.Peek());
                astroStack.Pop();
                aCount--;
            }
            //while there are still janitors in the stack, load the queue
            while (jCount > 0)
            {
                droidQueue.Enqueue(janiStack.Peek());
                janiStack.Pop();
                jCount--;
            }
            //while there are still utility in the stack, load the queue
            while (uCount > 0)
            {
                droidQueue.Enqueue(utilityStack.Peek());
                utilityStack.Pop();
                uCount--;
            }
            //while there are still protocol in the stack, load the queue
            while (pCount > 0)
            {
                droidQueue.Enqueue(protocolStack.Peek());
                protocolStack.Pop();
                pCount--;
            }
            //index for loading
            int i = 0;
            //while the total count of droids is larger than 0, rewrite the contents of the array from the queue
            while (totalCount > 0)
            {
                droidCollection[i] = droidQueue.Dequeue();
                totalCount--;
                i++;
            }
        }

        public void SortByCost()
        {

        }

    }
}
