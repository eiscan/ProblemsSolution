using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Problems.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Problems.GenerateCode
{
    public class GenerateCode
    {
        Dictionary<char, char> matches = new Dictionary<char, char>();
        public GenerateCode()
        {
            matches.Add('0', 'X');
            matches.Add('1', 'Y');
            matches.Add('6', 'Z');
            matches.Add('8', 'T');
            matches.Add('E', 'R');
            matches.Add('C', 'H');
            matches.Add('F', 'L');
        }
        
        private long GetTimeStamp(int addSeconds)
        {
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow.AddSeconds(addSeconds);
            return now.ToUnixTimeSeconds();
        }

        public string[] GenerateCodes()
        {
            List<string> codes = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                long timestamp = GetTimeStamp(i);
                string code = timestamp.ToString("X");

                foreach (char character in code)
                {
                    char value;
                    matches.TryGetValue(character, out value);
                    if (value != '\0')
                        code = code.Replace(character,value);
                }
                if (CheckCode(code))
                    codes.Add(code);
            }

            return codes.ToArray();
        }

        private bool CheckCode(string code)
        {
            string characters = "ACDEFGHKLMNPRTXYZ234579";
            foreach (char c in code.ToCharArray())
            {
                if (characters.IndexOf(c) == -1)
                    return false;
            }
            return true;
        }

        public string DeGenerateCode(string code)
        {
            foreach (char character in code)
            {
                char value;
                matches.TryGetKey(character, out value);
                if (value != '\0')
                    code = code.Replace(character, value);
            }
            long again = Convert.ToInt64(code, 16);
            return again.ToString();
        }
    }
}
