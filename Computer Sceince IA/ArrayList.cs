using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Sceince_IA
{
    class ArrayList<T> //where T : class
    {
        private T[] data;

        /// <summary>
        /// Constructor
        /// </summary>
        public ArrayList()
        {
            data = new T[0];
        }

        /// <summary>
        ///Seraches to check if an item exists
        ///pre: Valid input 
        ///post: returns bool if found
        /// </summary>
        public bool Has(T input)
        {
            if(input != null)
            {
                for (int x = 0; x < this.data.Length; x++)
                {
                    if (data[x].Equals(input))
                    {
                        return true;
                    }
                }

            }

            return false;
        }

        //Mutator//

        /// <summary>
        /// Inserts input to the requested index of the array
        /// pre: Valid input
        /// post: Array is updated
        /// </summary>
        public void Add(int index, T input)
        {
            T[] newData = new T[data.Length + 1];
            int count = 0;
            for (int i = 0; i < newData.Length; i++)
            {
                if (index == i)
                {
                    newData[i] = input;
                }
                else
                {
                    newData[i] = data[count];
                    count++;
                }
            }
            data = newData;
        }

        /// <summary>
        /// Inserts the input to the start of the array
        /// pre: Valid input 
        /// post: Pre-pended array
        /// </summary>
        public void AddFirst(T input)
        {
            Add(0, input);
        }

        /// <summary>
        /// Inserts the input to the start of the array
        /// pre: Valid input 
        /// post: Appended array
        /// </summary>
        public void AddLast(T input)
        {
            Add(data.Length, input);
        }

        /// <summary>
        /// Removes the values in the index from the array 
        /// pre: Valid index input
        /// post: Amended array
        /// </summary>
        public void Remove(int index)
        {
            if(data.Length != 0)
            {
                T[] newData = new T[data.Length - 1];
                int count = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    if (i != index)
                    {
                        newData[count] = data[i];
                        count++;
                    }
                }
                data = newData;
            }
        }

        /// <summary>
        /// Removes first value of array
        /// pre: Valid index input
        /// post: Amended array
        /// </summary>
        public void RemoveFirst()
        {
            Remove(0);
        }

        /// <summary>
        /// Removes last value of array
        /// pre: Valid index input
        /// post: Amended array
        /// </summary>
        public void RemoveLast()
        {
            Remove(data.Length - 1);
        }

        /// <summary>
        /// Removes value passed in from the array
        /// pre: Valid index input
        /// post: Amended array
        /// </summary>
        public void RemoveString(T value)
        {
            for (int i = (data.Length - 1); i >= 0; i--)
            {
                if (Get(i).Equals(value))
                {
                    Remove(i);
                }
            }
        }

        //Accessor//

        /// <summary>
        /// Returns a value from specific index
        /// pre: Valid index
        /// post: Returns value
        /// </summary>
        public T Get(int index)
        {
            if (data[index] != null)
            {
                return data[index];
            }
            return default(T);
        }

        /// <summary>
        /// Returns the first vlaue in teh array
        /// post: Value T returned
        /// </summary>
        public T GetFirst()
        {
            return Get(0);
        }

        /// <summary>
        /// Returns the last vlaue in teh array
        /// post: Value T returned
        /// </summary>
        public T GetLast()
        {
            return Get(data.Length - 1);
        }

        //Modifications//

        /// <summary>
        /// All values in array cleared
        /// post: No reference to array
        /// </summary>
        public void Clear()
        {
            data = new T[0];
        }

        /// <summary>
        /// Checks if array has any values 
        /// post: Returns bool
        /// </summary>
        public bool isEmpty()
        {
            if (data.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Converts List to an array
        /// post: Array retruned
        /// </summary>
        public T[] ToArray()
        {
            T[] Array = new T[this.Size()];

            for(int x = 0; x < this.Size(); x++)
            {
                Array[x] = this.Get(x);
            }

            return Array;
        }

        /// <summary>
        /// Returns int value of length
        /// </summary>
        public int Size()
        {
            return data.Length;
        }
    }
}
