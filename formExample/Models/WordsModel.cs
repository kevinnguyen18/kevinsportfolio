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
                    while ((currentLine = lineReader.ReadLine()) != null)
                    {
                        tempLine = currentLine;
                        matchingWordsArray.Add(tempLine); //Add to allWordsArray
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
    }
}
 