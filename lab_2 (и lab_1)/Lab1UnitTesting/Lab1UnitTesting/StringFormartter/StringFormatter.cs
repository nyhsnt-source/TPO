using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1UnitTesting
{
    public class StringFormatter: IStringFormatter
    {
        #region Fields
        private String nullEx = "NullReferenceException, the input string is NULL";
        private String[] sqlKeys = { "select", "from", "where", "insert", "update", "delete"};
        #endregion

        #region Constructors
        public StringFormatter() { }
        public StringFormatter(String testString) { }
        #endregion

        #region Methods
        /// <summary>
        /// Format string to SQL standarts:
        /// 1) changes "'" to "''" (protects from missunderstanding)
        /// 2) changes SQL key words register (e.g. insert -> INSERT)
        /// 3) if the initial string is empty("") returns an empty string as well
        /// 4) if the initial string is NULL throuths NullReferenceException 
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>
        /// Formated string
        /// </returns>
        public String SaveString(String s)
        {
            String new_s = "";
            if (s == null)
                throw new System.NullReferenceException(nullEx);

            new_s=stringToUpper(s);

            new_s = stringReplacing(new_s);

            return new_s;
        }

        /// <summary>
        /// Changes SQL key words register (e.g. insert -> INSERT)
        /// </summary>
        /// <param name="temp"></param>
        /// <returns>
        /// Changed String
        /// </returns>
        public String stringToUpper(String temp)
        {
            String new_temp=temp;
            for (int i = 0; i < sqlKeys.Length; i++)
            {
                if (temp.Contains(sqlKeys[i]))
                {
                    new_temp = new_temp.Replace(sqlKeys[i], sqlKeys[i].ToUpper());
                }
            }
            return new_temp;
        }

        /// <summary>
        /// Changes "'" to "''" (protects from missunderstanding)
        /// </summary>
        /// <param name="temp"></param>
        /// <returns>
        /// Formarted String
        /// </returns>
        public String stringReplacing(String temp)
        {
            if (temp.Contains("'"))
            {
                temp = temp.Replace("'", "''");
            }
            return temp;
        }

        #endregion

    }
}
