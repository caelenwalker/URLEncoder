using System;
using System.IO;
using System.Collections.Generic;

namespace URLEncoder {
    class program {
        static string urlFormatString = "https://companyserver.com/content/{0}/files/{1}/{1}Report.pdf";
        
        static void Main(string[] args){
            Console.WriteLine("*** URL Encoder ***");

            do {
                Console.Write("\nProject name: ");
                string projectName = GetUserInput();
                Console.Write("Activity name: ");
                string activityName = GetUserInput();

                Console.WriteLine(CreateURL(projectName, activityName));

                Console.Write("Would you like to do another? (y/n): ");
            } while(Console.ReadLine().ToLower().Equals("y"));
        }

        static string CreateURL(string projectName, string activityName) {
            string finalURL = "";
            try {
                finalURL = Encode(String.Format(urlFormatString, projectName, activityName));
            }  
            catch(Exception e) {
                Console.Write(e);
            }
            return finalURL;
        }

        static string GetUserInput() {
            string input;
            do {
                input = Console.ReadLine();
                if (IsValid(input)) 
                    return input;
                else
                Console.Write("The input contains invalid characters. Enter again: ");
            } while (true);
        }

        static bool IsValid(string input) {
            int[] notAllowed = {0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 
            0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18,
            0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F, 0x7F};

            foreach(char inputCharacters in input.ToCharArray()) {
                for(int i = 0; i < notAllowed.Length; i++) {
                    if(inputCharacters == notAllowed[i]) 
                        return false;
                }
            }
            return true;
        }

        static string Encode(string value) {
            string encodedValue = value;

            encodedValue = encodedValue.Replace(" ", "%20");
            encodedValue = encodedValue.Replace(" ", "%20");
            encodedValue = encodedValue.Replace(";", "%3B");
            encodedValue = encodedValue.Replace(":", "%3A");
            encodedValue = encodedValue.Replace("@", "%40");
            encodedValue = encodedValue.Replace("&", "%26");
            encodedValue = encodedValue.Replace("=", "%3D");
            encodedValue = encodedValue.Replace("+", "%2B");
            encodedValue = encodedValue.Replace("$", "%24");

            encodedValue = encodedValue.Replace("{", "%7B");
            encodedValue = encodedValue.Replace("}", "%7D");
            encodedValue = encodedValue.Replace("|", "%7C");
            encodedValue = encodedValue.Replace(@"\", "%2B");
            encodedValue = encodedValue.Replace("^", "%5E");
            encodedValue = encodedValue.Replace("[", "%5B");
            encodedValue = encodedValue.Replace("]", "%5D");
            encodedValue = encodedValue.Replace("'", "%80");
            
            return encodedValue;
        }
    }
}