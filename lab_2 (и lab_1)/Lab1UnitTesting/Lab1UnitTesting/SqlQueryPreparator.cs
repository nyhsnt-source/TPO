using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1UnitTesting
{
    public class SqlQueryPreparator
    {
        #region Fields
        private IStringFormatter sf;
        #endregion

        #region Constructors

        public SqlQueryPreparator() 
        {
            sf = new StringFormatter();
        }
        public SqlQueryPreparator(IStringFormatter sf) 
        {
            this.sf = sf;
        }

        // Свойство, через которое будет внедрена зависимость.
        public IStringFormatter StringFormatter
        {
            set { sf = value; }
            get
            {
                if (sf == null)
                {
                    throw new MemberAccessException("StringFormatter has not been initialized.");
                }
                return sf;
            }
        }

        #endregion

        #region Methods

        public String[] PrepareQueries(String[] queries)
        {
            //StringFormatter sf = new StringFormatter();
            List<String> formated_queries = new List<String>();

            for(int i=0; i<queries.Length; i++)
            {
                formated_queries.Add(sf.SaveString(queries[i]));
                Console.WriteLine(formated_queries[i]);
            }

            return formated_queries.ToArray();
        }

        #endregion
    }
}
