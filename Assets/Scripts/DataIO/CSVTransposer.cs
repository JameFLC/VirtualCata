using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

// CSV Transposer based on https://stackoverflow.com/users/6136178/dunkleosteus implementation from https://stackoverflow.com/a/51307684 in the https://stackoverflow.com/questions/51306985/reading-csv-file-and-converted-to-transposed-table article




// IMPORTANT !!! => This CSV transposer une this (,) character to seperate strings so thoses string should not contain any (,) ! 



class CSVTransposer
{
   public static void Transpose(string csvPath)
    {
        StreamReader sr1 = new StreamReader(csvPath);  //create the streamreader to read the input .csv
        DataTable mydata = new DataTable();  //create an empty DataTable.....
        string[] arr;                        //....and an array in which you will store the elemnets of each line
        int i = 0;                           //just a variable to help counting where you are in your data
        bool mydatasetup = false;            //a variable to check in the loop if you already added the necessary number of columns to the datatable 

        using (sr1)
        {
            while (sr1.EndOfStream == false)    //read the whole file
            {
                string line = sr1.ReadLine();    //get a line from the file

                if (line != null && line != String.Empty) //check if there is content in the line
                {
                    arr = line.Split(',');    //split the line at each ";" and put the elements in the array

                    if (mydatasetup == false)   //after reading the first line add as many columns to your datatable as you will need..... 
                    {
                        for (int u = 0; u < arr.Length; u++)
                        {
                            mydata.Columns.Add();
                        }
                        mydatasetup = true; //...but only do this once (otherwise you wil have an unneccessary big datatable
                    }

                    mydata.Rows.Add();   //add a row in you datatable in which you will store the data of the line

                    for (int j = 0; j < arr.Length; j++)    //go throught each element in your array and put it into your datatable
                    {
                        if (arr[j] != "")
                        {
                            mydata.Rows[i][j] = arr[j];
                        }
                    }
                    i = i + 1; //increase the counter so that the program knows it has to fill the data from the next line into the next row of the datatable
                }
            }
            StringBuilder sb = new StringBuilder();  //create a stringbuilder

            for (int u = 0; u < mydata.Columns.Count; u++)   //loop through the COLUMNS of your datatable....
            {
                for (int w = 0; w < mydata.Rows.Count; w++)  //....but for each column go through each row in the datatable first  
                {
                    sb.Append(mydata.Rows[w][u].ToString()); // and add the elements to the stringbuilder - here the transposing is actually done

                    if (w < mydata.Rows.Count - 1)   //add a deliminator after each element because you want a .csv as output again 
                    {
                        sb.Append(';');
                    }
                }
                sb.AppendLine(); //add another line to your stringbuilder in which you will store the next column of your datatable
            }
            string outputpath = csvPath.Substring(0, csvPath.Length-4) + "_VerticallyTransposed.csv";
            Debug.Log("CSV Transposed to : " + outputpath);
            File.WriteAllText(outputpath, sb.ToString());  //finally create the output .csv  
        }
        
    }
}
