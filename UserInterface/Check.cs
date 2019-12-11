using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    /// <summary>
    /// Class Check defines many functions for checking that strings are in the desired format 
    /// for either parsing or storing. If not, a user friendly message is stored as to why 
    /// the string or variable is not in the desired format
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// Checks if char c is a number or not
        /// </summary>
        /// <param name="c">The character to check</param>
        /// <returns>Whether char c is a number or not</returns>
        public static bool IsNumber(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks whether char c is a letter or not
        /// </summary>
        /// <param name="c">Whether c is a letter or not</param>
        /// <returns>Whether c is a letter or not</returns>
        public static bool IsLetter(char c)
        {
            if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks whether string contains only characters or not; if not, displays appropriate message to user
        /// </summary>
        /// <param name="name">The name of variable</param>
        /// <param name="s">The string to check</param>
        /// <param name="message">Any message to display</param>
        /// <returns>Whether name contains only characters or not</returns>
        public static bool ValidSingleName(string name, string s, out string message)
        {
            message = "";
            if (s == "")
            {
                message = "Please enter a " + name;
            }
            else
            {
                foreach (char c in s)
                {
                    if(c == ' ')
                    {
                        message = name + " must be a single word";
                        return false;
                    }
                    if (!IsLetter(c))
                    {
                        message = name + " must contain only characters";
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks whether name contains only characters or not; if not, displays appropriate message to user
        /// </summary>
        /// <param name="name">The name of variable</param>
        /// <param name="s">The string to check</param>
        /// <param name="message">Any message to display</param>
        /// <returns>Whether name contains only characters or not</returns>
        public static bool ValidName(string name, string s, out string message)
        {
            message = "";
            if (s == "")
            {
                message = "Please enter a " + name;
            }
            else
            {
                foreach (char c in s)
                {
                    if (!IsLetter(c) && c != ' ')
                    {
                        message = name + " must contain only characters";
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check whether number is a valid positive integer; if not, display message to user
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <param name="num">The number to check</param>
        /// <param name="message">Message to display to user</param>
        /// <returns>Whether number is a valid positive integer</returns>
        public static bool ValidPositiveInt(string name, string num, out string message)
        {
            message = "";
            if (num == "")
            {
                message = "Please enter a " + name;
            }
            else
            {
                if (num[0] == '-')
                {
                    message = name + " must be a non-negative integer";
                }
                else
                {
                    foreach (char c in num)
                    {
                        if (!IsNumber(c))
                        {
                            message = name + " must contain only numbers";
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check whether valid price or not; if not, display message to user
        /// </summary>
        /// <param name="name">The name of the variable</param>
        /// <param name="f">The float in question</param>
        /// <param name="message">Any message to return</param>
        /// <returns>Whether a valid positive float</returns>
        public static bool ValidPositiveFloat(string name, string f, out string message)
        {
            message = "";
            if (f == "")
            {
                message = "Please enter a " + name;
            }
            else
            {
                int numPeriods = 0;
                if (f[0] == '-')
                {
                    message = "Please enter a non-negative value";
                }
                for (int i = 1; i < f.Length; i++)
                {
                    char c = f[i];
                    if (c == '.')
                    {
                        numPeriods++;
                    }

                    if (!IsNumber(c) && c != '.')
                    {
                        message = name + " must be a number";
                        return false;
                    }

                    if (numPeriods > 1)
                    {
                        message = name + " must be a valid number";
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to confirm that a valid phone number was entered; if not, display appropriate message to user
        /// </summary>
        /// <param name="areaCode">Area code of the phone number</param>
        /// <param name="first3Digits">First 3 digits of phone number</param>
        /// <param name="last4Digits">Last 4 digits of phone number</param>
        /// <param name="message">Message to dispaly to user</param>
        /// <returns>Whether valid phone number was entered</returns>
        public static bool ValidPhoneNumber(string areaCode, string first3Digits, string last4Digits, out string message)
        {
            message = "";
            if (ValidPositiveInt("Area code", areaCode, out message) && ValidPositiveInt("Phone number", first3Digits, out message)
                && ValidPositiveInt("Phone number", last4Digits, out message))
            {
                if (areaCode.Length != 3)
                {
                    message = "Area code must be 3 digits";
                }
                else if (first3Digits.Length != 3)
                {
                    message = "Second box in phone number must be 3 digits";
                }
                else if (last4Digits.Length != 4)
                {
                    message = "Last box in phone number must be 4 digits";
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether a valid zipcode has been entered; if not, display message to user
        /// </summary>
        /// <param name="zip">The zip to check</param>
        /// <param name="message">Message to display to user</param>
        /// <returns>Whether a valid zipcode has been entered</returns>
        public static bool ValidZipcode(string zip, out string message)
        {
            message = "";
            if (ValidPositiveInt("Zipcode", zip, out message))
            {
                if (zip.Length != 5)
                {
                    message = "Zipcode must be a 5 digit code";
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check that a valid age has been entered; if not, display to the user
        /// </summary>
        /// <returns>Whether a valid age or not</returns>
        public static bool ValidAge(string ageStr, out string message)
        {
            message = "";
            if (ValidPositiveInt("Age", ageStr, out message))
            {
                int age = int.Parse(ageStr);
                if (age < 16)
                {
                    message = "Customer must be registered with someone at least 16";
                }
                else if (age > 150)
                {
                    message = "Recheck age";
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check to make sure that a sex has been selected; if not, display appropriate message.
        /// </summary>
        /// <param name="male">Whether male was selected</param>
        /// <param name="female">Whether female was selected</param>
        /// <param name="message">Message to display to user</param>
        /// <returns>Whether a sex has been selected</returns>
        public static bool ValidSex(bool? male, bool? female, out string message)
        {
            message = "";
            if (!(bool)male && !(bool)female)
            {
                message = "Please select a sex";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check whether a valid email has been entered; if not, display appropriate message to user
        /// </summary>
        /// <returns>Whether a valid email has been entered</returns>
        public static bool ValidEmail(string email, out string message)
        {
            message = "";
            if (email == "")
            {
                message = "Please enter an email";
            }
            else
            {
                int atChar = 0;
                int period = 0;
                for (int i = 0; i < email.Length; i++)
                {
                    if (email[i] == '@')
                    {
                        atChar++;
                    }
                    if (atChar == 1 && email[i] == '.')
                    {
                        period++;
                    }
                }
                if (atChar != 1)
                {
                    message = "A valid email contains only 1 @";
                }
                else if (period != 1)
                {
                    message = "A valid email contains 1 and only 1 period after the @";
                }
                else if (email[email.Length - 1] == '.')
                {
                   message = "A valid email does not end on a period";
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether a valid address has been entered; if not, display message to user
        /// </summary>
        /// <param name="name">The name of the variable</param>
        /// <param name="s">The string to check</param>
        /// <param name="message">Message to display to user</param>
        /// <returns>Whether a valid address has been entered</returns>
        public static bool NonNull(string name, string s, out string message)
        {
            message = "";
            if (s == "")
            {
                message = "Please enter a " + name;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check to see if check in date has been selected
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <param name="date">Date to check</param>
        /// <param name="message">Message to return to user</param>
        /// <returns>Whether check in date has been selected</returns>
        public static bool NonNull(string name, DateTime? date, out string message)
        {
            message = "";
            if (date == null)
            {
                message = "Please select a " + name;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether the given string is a valid time; it not, display message to user
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <param name="time">The time to check</param>
        /// <param name="message">Message to display to user</param>
        /// <returns></returns>
        public static bool ValidTime(string name, string time, out string message)
        {
            message = "";
            if(time == "")
            {
                message = "Please enter a " + name;
            }
            else
            {
                string[] splitTime = time.Split(':');
                if(splitTime.Length != 2)
                {
                    message = "A valid " + name + " is in the format hh:mm";
                }
                else if(!ValidPositiveInt(name + " hours", splitTime[0], out message))
                {                  
                    
                }
                else if(!ValidPositiveInt(name + " minutes", splitTime[1], out message))
                {

                }
                else
                {
                    int hours = int.Parse(splitTime[0]);
                    int minutes = int.Parse(splitTime[1]);
                    if(hours > 23)
                    {
                        message = name + " hours must be a value between 0 and 24";
                    }
                    else if(minutes > 59)
                    {
                        message = name + " minutes must be a value between 0 and 60";
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Formats string name to be upper case for first letter and lower for rest 
        /// </summary>
        /// <param name="name">The name to format</param>
        /// <returns>Formated string</returns>
        public static string FormatName(string name)
        {
            string formatName = "";
            if (name != "")
            {
                bool toUpper = true;
                for (int i = 0; i < name.Length; i++)
                {
                    if (toUpper)
                    {
                        formatName += char.ToUpper(name[i]);
                        if (IsLetter(name[i]))
                        {
                            toUpper = false;
                        }
                    }
                    else
                    {
                        formatName += char.ToLower(name[i]);
                    }

                    if (name[i] == ' ')
                    {
                        toUpper = true;
                    }
                }
            }
            return formatName;
        }

        /// <summary>
        /// Formats an objects toString into a particular length; if the string is too large, it just returns the string
        /// </summary>
        /// <param name="formatObject">The object to format</param>
        /// <param name="length">The length of characters to occupy</param>
        /// <param name="leftAlign">Whether the string is leftaligned or not</param>
        /// <returns>The formated string</returns>
        public static string Format(object formatObject, int length, bool leftAlign)
        {
            if(formatObject == null)
            {
                return null;
            }
            string s = formatObject.ToString();

            int numSpaces = length - s.Length;
            if(numSpaces <= 0)
            {
                return s;
            }

            if (leftAlign)
            {
                for (int i = 0; i < numSpaces; i++)
                {
                    s += " ";
                }
                return s;
            }
            else
            {
                for(int i = 0; i < numSpaces; i++)
                {
                    s = " " + s;
                }
                return s;
            }
        }

        /// <summary>
        /// Gets the number at the end of a string
        /// </summary>
        /// <param name="s">The string to read in</param>
        /// <returns>The number at the end of a string</returns>
        public static int GetNumberAtEndOfString(string s)
        {
            string number = "";
           for(int i = s.Length - 1; i >= 0; i--)
           {
                if(IsNumber(s[i]))
                {
                    while(i >= 0 && IsNumber(s[i]))
                    {
                        number = s[i] + number;
                        i--;
                    }
                    return int.Parse(number);
                }
           }
           return 0;
        }
    }
}
