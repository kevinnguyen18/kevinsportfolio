using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.IO;

namespace formExample.Models
{
    public class WordsModel
    {
        public ArrayList ArrayListOfSpecificWords { get; set; }
        public ArrayList matchingWordsArray = new ArrayList();

        /*
        * @param - Takes in a file name as a string and attaches it to the current Directory to read from a file
        */
        public string ReadFile(string folderAndFileName, string userStringInput)
        {

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            string path = Directory.GetCurrentDirectory() + folderAndFileName;

            try
            {

                using (StreamReader lineReader = new StreamReader(path))
                {
                    string currentLine = null;
                    string tempLine = null;
                    int exactMatchTracker = 0;
                    char[] userInputCharacterArray = new char[userStringInput.Length];
                    
                    while ((currentLine = lineReader.ReadLine()) != null)
                    {

                        CreateUserInputArray( userStringInput, userInputCharacterArray);
                        tempLine = currentLine;
                        DecideIfWordMatches(tempLine, userStringInput,  userInputCharacterArray,  exactMatchTracker);
                        ResetTrackerAndUserWordInput(exactMatchTracker, userInputCharacterArray, userStringInput);


                    }
                    return tempLine;

                }
            }

            catch (Exception exception)
            {

                return "The file could not be read.";
            }
        }

        private void DecideIfWordMatches(string tempLine, string userStringInput, char[] userInputCharacterArray, int exactMatchTracker)
        {
            for (int i = 0; i < tempLine.Length; i++)
            {
                for (int j = 0; j < userStringInput.Length; j++)
                {
                    if (Char.ToLower(tempLine[i]) == Char.ToLower(userInputCharacterArray[j]))
                    {
                        exactMatchTracker++;
                        userInputCharacterArray[j] = '1';//Marks index as a '1' so we know it's a match


                        if ((exactMatchTracker == tempLine.Length) && (exactMatchTracker != 0))
                        {
                            matchingWordsArray.Add(tempLine);
                        }
                        j = userStringInput.Length;
                    }
                    else
                    {
                        //Do nothing
                    }

                }

            }
        }

        /*
         * @param userStringInput - Takes int the letters of user input to have a list characters to use to form words
         * @param userStringInput - List of characters that match the user Input. If there is a match then the slot in the array 
         *                          will be null to show that the word has already been used.
         *          
         * This method takes the string that was inputted by the user and stores each character in the string into an array.
         */
        private void CreateUserInputArray(string userStringInput, char[] userInputCharacterArray)
        {
            for (int wordIndex = 0; wordIndex < userStringInput.Length; wordIndex++)
            {
                userInputCharacterArray[wordIndex] = userStringInput[wordIndex];
            }
        }


        private void ResetTrackerAndUserWordInput(int exactMatchTracker, char[] userInputCharacterArray, string userStringInput)
        {
            exactMatchTracker = 0;
            userInputCharacterArray = new char[userStringInput.Length];
        }


        /*
         * Returns an array of matching words
         */
        public ArrayList getArray()
        {
            return matchingWordsArray;
        }

        public string removeCharAt(int index, string word)
        {
            string newUserWord = null;
            for(int i = 0; i < word.Length; i++)
            {
                if(i == index)
                {
                    
                }
                else
                {
                    newUserWord = newUserWord + word[i].ToString();
                }
            }
            return newUserWord;
        }
    }
}
 