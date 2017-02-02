using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FlattenArray
{
    class Program
    {

        static void Main(string[] args)
        {
            //Test array for flattening
            var list = new List<object> { new List<object> { 45 }, 21, new List<object> { new List<object> { 33, 45 }, 5 }, new List<object> { new List<object> { new List<object> { } } }, new List<object> { new List<object> { new List<object> { 67 } } }, 32, 89, new List<object> { } };
            // Print it out
            Console.WriteLine("[" + list.FlattenArray().Join(", ") + "]");
            Console.ReadLine();
        }
    }
    /*
     * extension method to flatten the array list
     * It will take a jagged array
     */
    public static class ExtensionMethodFlatten                 
    {
        public static List<object> FlattenArray(this List<object> list)
          {

            var resultant_array = new List<object>();
            foreach (var item in list)
            {
                if (item is List<object>)
                {
                    resultant_array.AddRange(FlattenArray(item as List<object>));
                }
                else
                {
                    resultant_array.Add(item);
                }
            }
            return resultant_array;
        }
        public static string Join<T>(this List<T> list, string delimit)
        {
            return string.Join(delimit, list.Select(i => i.ToString()).ToArray());
        }
    }

}
