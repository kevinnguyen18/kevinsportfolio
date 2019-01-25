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
            //return path;
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

                        for(int wordIndex = 0; wordIndex < userStringInput.Length; wordIndex++)
                        {
                            userInputCharacterArray[wordIndex] = userStringInput[wordIndex];
                        }
                        tempLine = currentLine;
                        for(int i = 0; i < tempLine.Length; i++)
                        {
                            for(int j = 0; j < userStringInput.Length; j++)
                            {
                                if(Char.ToLower(tempLine[i]) == Char.ToLower(userInputCharacterArray[j]))
                                {
                                    exactMatchTracker++;
                                    //userStringInput = removeCharAt(j, userStringInput);
                                    //userInputCharacterArray[j] = null;
                                    //matchingWordsArray.Add(userInputCharacterArray[j]);
                                    userInputCharacterArray[j] = '1';
                                    

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
                        exactMatchTracker = 0;
                        userInputCharacterArray = new char[userStringInput.Length];
                        //matchingWordsArray.Add(tempLine); //Add to allWordsArray
                    }
                    return tempLine;

                }
            }

            catch (Exception exception)
            {

                return "The file could not be read.";
            }
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
 