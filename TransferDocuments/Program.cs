using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TransferDocuments
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dsResult = new DataSet();

            dsResult = GetData();

            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dsResult.Tables[0].Rows)
                {
                    TransferDocuments(row);
                    UpdateRecord(row);
                }

            }

        }

        private static DataSet GetData()
        {
            DataSet dsResult = new DataSet();


            return dsResult;
        }

        public static void TransferDocuments(DataRow row)
        {

        }

        private static void UpdateRecord(DataRow row)
        {

        }

    }
}
