using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace ConsoleApp
{
    public class BowlingGame
    {
        static void Main(string[] args)
        {

            //Assumptions 
            //ArrayList will have exaclty 10 elements one for each round
            //There is no input validations 

            ArrayList data = new ArrayList();
            data.Add(new int[] { 10 });  //1st throw
            data.Add(new int[] { 9, 1 }); //2nd throw
            data.Add(new int[] { 5, 5 }); //3rd throw
            data.Add(new int[] { 7, 2 }); //4th throw
            data.Add(new int[] { 10 }); //5th throw
            data.Add(new int[] { 10 }); //6th throw
            data.Add(new int[] { 10 }); //7th throw
            data.Add(new int[] { 9, 0 }); //8th throw
            data.Add(new int[] { 8, 2 }); //9th throw
            data.Add(new int[] { 9, 1, 10 }); //10th throw

            int sum = CalculateTotal(data);

            Console.WriteLine($"Total sum is : {sum}");


        }

        /// <summary>
        /// Accepts ArrayList as parameter
        /// The element inside each array will be exactly equal to number of throws in given round
        /// Returns Sum of score after all the round based of Bowling game rules for score calculation
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int CalculateTotal(ArrayList list)
        {
            int retData = 0;

            for (int i = 0; i < 10; i++)
            {
                //Last throw
                if (i == 9)
                {
                    int j = 0;
                    var array = (int[])list[i];

                    while (j < array.Length)
                    {
                        retData += array[j];
                        j++;
                    }
                }
                //From 1-9 throw
                else
                {
                    var array = (int[])list[i];
                    var array1 = (int[])list[i + 1];
                    //Niether strike nor spare
                    if (array.Length == 2 && (array[0] + array[1] != 10))
                    {
                        retData += (array[0] + array[1]);
                    }
                    //spare
                    //We need to add the next throws first outcome
                    else if (array.Length == 2 && (array[0] + array[1] == 10))
                    {
                        retData += (array[0] + array[1]);
                        retData += array1[0];
                    }
                    //strike
                    //Array will have only one element as it's a strike
                    //We need to add next two throws outcome
                    else
                    {
                        retData += 10;
                        //Case 1 when array1 Lenght >= 2
                        if (array1.Length >= 2)
                        {
                            retData += array1[0] + array1[1];
                        }
                        //Case 2 when array1 is also strike
                        else
                        {
                            var array2 = (int[])list[i + 2];
                            retData += array1[0] + array2[0];
                        }
                    }

                }

                //Console.WriteLine($"Sum after {i} throw is : {retData}.");

            }


            return retData;
        }


    }
}
