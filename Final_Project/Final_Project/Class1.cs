using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class LibraryItems
    {


        public int itemID;
        public string itemName;
        public string mediaType;
        public double lateFee; //REMEBER: THIS IS DAILY, THEREFORE IT'S LATEFEE * NUM OF DAYS LATE
        public bool available;

        //adding new item to catalogue method
        public LibraryItems(int v1, string v2, string v3, double v4, bool v5)
        {
            this.itemID = v1;
            this.itemName = v2;
            this.mediaType = v3;
            this.lateFee = v4;
            this.available = v5;
        }


        public static List<LibraryItems> catalog;

        //functions for the Class

        //attempt 1 of availability BOOL
        public void toggleAvailability() //change to checkout?
        {

            if (available)
            {
                available = false;
            }
            else
            {
                available = true;
            }
        }

        //printing all items in catalogue method
        public static void ViewCatalog()
        {
            //writeline loop for each item, formatting to diaplay the information undersandably.
            //use if/else about the availability , if true print available, else print unavailable
            
            foreach (var it in catalog)
            {
                if (it.available)
                {
                    Console.WriteLine($"{it.itemID}.  {it.itemName}, {it.mediaType} - {it.lateFee}: !!!Available!!!! ");
                }
                else
                {
                    Console.WriteLine($"{it.itemID}.  {it.itemName}, {it.mediaType} - {it.lateFee}: !!UNavailable--- ");
                }
                
            }
        }
       
        

    }
}