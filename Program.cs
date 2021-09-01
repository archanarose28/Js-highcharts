﻿using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace JavaScriptDataproj
{

    public class CompanyMas
    {
        public string AUTHORIZED_CAP { get; set; }
        public string DATE_OF_REGISTRATION { get; set; }

        public string PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN { get; set; }

    }
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<double, double> countVal = new Dictionary<double, double>();
            double valFive = 0;  //

            countVal.Add(100000, 0);
            countVal.Add(1000000, 0);
            countVal.Add(10000000, 0);
            countVal.Add(100000000, 0);
            countVal.Add(1000000000, valFive);

            using (var reader = new StreamReader("C:\\Users\\ARCHANA ROSE BIJU\\Downloads\\Tripura.csv")) //TESTCASE1
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        int flag = 0;
                        var record = csv.GetRecord<CompanyMas>();
                        double k = Convert.ToDouble(record.AUTHORIZED_CAP);
                        foreach (KeyValuePair<double, double> kvp in countVal)
                        {
                            double val = kvp.Key;
                            if (k <= val)
                            {
                                flag = 1;
                                countVal[val] += 1;
                                break;
                            }

                        }
                        if (flag == 0)
                            valFive++;

                    }
                }

            }
            Console.WriteLine("BIN " + "                                  COUNTS");

            //convert to json here
            string Json = JsonConvert.SerializeObject(countVal, Formatting.Indented);
            string writePath = @"C:\Users\ARCHANA ROSE BIJU\mountblue projects\jsDataproject\case1.json"; 
            System.IO.File.WriteAllText(writePath, Json);
            Console.WriteLine(Json);

            //TESTCASE2
            Dictionary<int, int> yearCount = new Dictionary<int, int>();
            for (int j = 2000; j <= 2019; j++)
            {
                yearCount.Add(j, 0);

            }
            using (var reader = new StreamReader("C:\\Users\\ARCHANA ROSE BIJU\\Downloads\\Tripura.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var record = csv.GetRecord<CompanyMas>();

                    string dateStr = record.DATE_OF_REGISTRATION;
                    DateTime checkDate = Convert.ToDateTime(dateStr);
                    int eachYear = checkDate.Year;

                    if (yearCount.ContainsKey(eachYear))
                        yearCount[eachYear]++;
                }

            }

            Console.WriteLine("YEAR " + "                                  COUNT");

            //convert to json here

            string Json2 = JsonConvert.SerializeObject(yearCount, Formatting.Indented);
            string writePath2 = @"C:\Users\ARCHANA ROSE BIJU\mountblue projects\jsDataproject\case2.json";
            System.IO.File.WriteAllText(writePath2, Json2);
            Console.WriteLine(Json2);

            //TESTCASE 3


            Dictionary<string, int> principle = new Dictionary<string, int>();
            using (var reader = new StreamReader("C:\\Users\\ARCHANA ROSE BIJU\\Downloads\\Tripura.csv"))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {

                    var rows = csv.GetRecords<CompanyMas>();
                    foreach (var row in rows)
                    {

                        string pba = row.PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN;
                        string dateStr = row.DATE_OF_REGISTRATION;
                        DateTime checkDate = Convert.ToDateTime(dateStr);
                        int eachYearr = checkDate.Year;
                        if (eachYearr == 2015)
                        {
                            if (principle.ContainsKey(pba))
                                principle[pba] += 1; //PRINCIPLE[key] = value. so, PRINCIPLE[pba]+=1 increments value2
                            else  //First occurrence of string pba in 2015
                                principle.Add(pba, 1);
                        }
                    }  //foreach     
                }
            }
            Console.WriteLine("PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN " + "                                  Count");
            //convert to json here

            string Json3 = JsonConvert.SerializeObject(principle, Formatting.Indented);
            string writePath3 = @"C:\Users\ARCHANA ROSE BIJU\mountblue projects\jsDataproject\case3.json"; 
            System.IO.File.WriteAllText(writePath3, Json3);
            Console.WriteLine(Json3);



            //TESTCASE 4

            Dictionary<int, Dictionary<string, int>> groupAggr = new Dictionary<int, Dictionary<string, int>>();
            //First adding 2000 to 2019  in dictionary to maintain the order of years in DICTIONARY
            for (int k = 2000; k <= 2019; k++)
            {
                groupAggr.Add(k, new Dictionary<string, int>());
            }
            using (var reader = new StreamReader("C:\\Users\\ARCHANA ROSE BIJU\\Downloads\\Tripura.csv"))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {

                    var rows = csv.GetRecords<CompanyMas>();
                    foreach (var row in rows)
                    {
                        string pba = row.PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN;
                        string dateStrr = row.DATE_OF_REGISTRATION;
                        DateTime checkDatee = Convert.ToDateTime(dateStrr);
                        int eachYearr = checkDatee.Year;
                        if ((eachYearr >= 2000) && (eachYearr <= 2019))
                        {
                            if (!(groupAggr[eachYearr].ContainsKey(pba)))      // No single string in this year in dictionary , so add 1 , since FIRST OCCURRENCE of string
                                groupAggr[eachYearr].Add(pba, 1);
                            else if (groupAggr[eachYearr].ContainsKey(pba)) // string are already present so increment its count
                                groupAggr[eachYearr][pba] += 1;
                        }
                    }
                }
            }
            Console.WriteLine("PRINCIPAL_BUSINESS_ACTIVITY_AS_PER_CIN " + "                                  COUNTS");
            //convert to json here

            string Json4 = JsonConvert.SerializeObject(groupAggr, Formatting.Indented);
            string writePath4 = @"C:\Users\ARCHANA ROSE BIJU\mountblue projects\jsDataproject\case4.json"; 
            System.IO.File.WriteAllText(writePath4, Json4);
            Console.WriteLine(Json4);
        }
    }
}



