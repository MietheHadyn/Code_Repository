using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_Project
{
    internal class CheckoutItems
    {

        public int ItemID;
        public string? ItemName;
        public string? MediaType;
        public double LateFee;
        //the ? means it can be null, needed (so far) to parse out the vairables from loading a file

        

        //current issue: _library is null??
        //public CheckoutItems(LibraryItems library)
        //{
        //    ArgumentNullException.ThrowIfNull(library); //throws an ArgumentNullException if library is null
        //    _library = library;
        //}
        //create some connection to LibraryItems class
        public DateOnly CheckedOutDate;
        //public DateOnly DueDate;
        public int DaysLate; //calc days late by subtracting due date from current date(?) and saving that as an integer to multiply the late fee by

        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

        public CheckoutItems(int v1, string v2, string v3, double v4)
        {
            this.ItemID = v1;
            this.ItemName = v2;
            this.MediaType = v3;
            this.LateFee = v4;
            
        }

        public CheckoutItems() { }  // allows new CheckoutItem() with no arguments


        //define duedate
        public DateOnly DueDate()
        {
            return currentDate.AddDays(4);
        }

        public static List<CheckoutItems> checkoutCatalog = new();

        //functions for the Class

        public int CalcDaysLate()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var due = DueDate();

            // convert to DateTime at midnight to obtain a TimeSpan difference in days
            var diffDays = (today.ToDateTime(TimeOnly.MinValue) - due.ToDateTime(TimeOnly.MinValue)).Days;

            DaysLate = Math.Max(0, diffDays);
            return DaysLate;
        }

        //calculate estimated late fee, considering the fee itself per item, # of days late, & add the other fees from other items
        public static decimal CalcLateFeeTotal()
        {
            decimal fee = 0;
            // computed days late
            //convert to decimal for money
            foreach (var item in checkoutCatalog)
            {
                fee += (decimal) item.LateFee * item.DaysLate;
                return fee;
            }
            return fee;
        }

        

        //create the Checkout receipt printing method here
        public static void ViewCheckout()
        {
            if (checkoutCatalog == null || checkoutCatalog.Count == 0)
            {
                Console.WriteLine("No checked-out items.");
                return;
            }

            foreach (var item in checkoutCatalog)
            {
                // ensure days late is up to date for this checkout
                item.CalcDaysLate();

                // use the linked LibraryItems fields (accessible inside the same class)
                Console.WriteLine($"{item.ItemID}.  {item.ItemName}, {item.MediaType} - {item.LateFee:C} | Days late: {item.DaysLate}");
            }
        }

        //format each item to a string to save into file
        public string FormatItem()
        {
             return $" ID: {ItemID.ToString()} | Item: {ItemName} | Media Type: {MediaType} | Late Fee: {LateFee.ToString("C")} | Days Late: {DaysLate}";
               
        }

    }
}
