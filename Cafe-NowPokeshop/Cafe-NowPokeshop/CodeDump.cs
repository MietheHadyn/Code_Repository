using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_NowPokeshop
{
    internal class CodeDump
    {
        static void AddItem()
        {
            ////print out the menu with prices

            //Console.WriteLine("Would you like to order? (Y/N)");

            //string orderBOOL = Console.ReadLine();
            //bool askorder = false;
            ////ask if customer would like to order
            //if (orderBOOL == "Y")
            //{
            //    askorder = true;
            //}
            //Menu();
            ////start order if true(Y)
            //int userChoice = 0;
            //try
            //{
            //    userChoice = int.Parse(Console.ReadLine());
            //    if ("bad" == "ReallyBad")
            //    {
            //        throw new Exception();
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    AddItem();
            //}
            //Menu();
            //if (askorder == true)
            //{
            //    //select and store item to add
            //    Console.WriteLine("What would you like? (input item number)");
            //    string ItemInputstr = Console.ReadLine();
            //    int ItemInput = int.Parse(ItemInputstr);

            //    //select and store price WITHOUT qty


            //    //select and store price WITH qty



            //Console.Write("Would you like to remove an item from cart? (Y/N): ");
            //string rmvBOOL = Console.ReadLine()?.Trim().ToUpperInvariant();

            //if (rmvBOOL == "Y")
            //{
            //    // print menu
            //    ViewCart();

            //    // ask for removal item number w/ validation)
            //    while (true)
            //    {
            //        Console.Write("What would you like to remove? (input item number, or 0 to cancel): ");
            //        string rmvInputStr = Console.ReadLine();
            //        if (!int.TryParse(rmvInputStr, out int rmvInput))
            //        {
            //            Console.WriteLine("Invalid input. Please enter a number.");
            //            continue;
            //        }

            //        if (rmvInput == 0)
            //        {
            //            Console.WriteLine("Removal cancelled.");
            //            break;
            //        }

            //        if (rmvInput < 0)
            //        {
            //            Console.WriteLine("Enter a positive number.");
            //            continue;
            //        }

            //    }

            //static void RemoveItem()
            //{
            //    if (CartItems.Count == 0)
            //    {
            //        Console.WriteLine("Cart is empty.");
            //        return;
            //    }

            //    ViewCart();

            //    while (true)
            //    {
            //        Console.Write("Would you like to remove an item? (Y/N): ");
            //        string answer = Console.ReadLine()?.Trim().ToUpperInvariant();
            //        if (answer == "N")
            //        {
            //            Console.WriteLine("Removal cancelled.");
            //            return;
            //        }
            //        if (answer != "Y")
            //        {
            //            Console.WriteLine("Please enter 'Y' or 'N'.");
            //            continue;
            //        }

            //        Console.Write("Enter item number to remove (or 0 to cancel): ");
            //        if (!int.TryParse(Console.ReadLine(), out int rmvInput) || rmvInput < 0)
            //        {
            //            Console.WriteLine("Invalid input. Please enter a positive number.");
            //            continue;
            //        }
            //        if (rmvInput == 0)
            //        {
            //            Console.WriteLine("Removal cancelled.");
            //            return;
            //        }

            //        int index = rmvInput - 1; // convert 1-based to 0-based
            //        if (index < 0 || index >= CartItems.Count)
            //        {
            //            Console.WriteLine($"Please enter a number between 1 and {CartItems.Count}.");
            //            continue;
            //        }

            //        int currentQty = CartQty[index];
            //        Console.WriteLine($"Selected: {CartItems[index]} x{currentQty} @ {CartPrices[index]:0.00} each.");
            //        Console.Write("How many would you like to remove? (enter 0 to cancel): ");
            //        if (!int.TryParse(Console.ReadLine(), out int rmvqty) || rmvqty < 0)
            //        {
            //            Console.WriteLine("Invalid quantity. Try again.");
            //            continue;
            //        }
            //        if (rmvqty == 0)
            //        {
            //            Console.WriteLine("Removal cancelled.");
            //            return;
            //        }

            //        if (rmvqty >= currentQty)
            //        {
            //            // remove entire line
            //            string removedName = CartItems[index];
            //            int removedQty = CartQty[index];
            //            CartItems.RemoveAt(index);
            //            CartPrices.RemoveAt(index);
            //            CartQty.RemoveAt(index);
            //            Console.WriteLine($"Removed {removedQty} x {removedName} (line removed).");
            //        }
            //        else
            //        {
            //            // partial removal: decrement quantity
            //            CartQty[index] = currentQty - rmvqty;
            //            Console.WriteLine($"Removed {rmvqty} from {CartItems[index]}. Remaining: {CartQty[index]}");
            //        }

            //        return;
            //   }

            /*
             *csharp Cafe-NowPokeshop\Program.cs
static void RemoveItem()
{
    if (CartItems.Count == 0)
    {
        Console.WriteLine("Cart is empty.");
        return;
    }

    ViewCart();

    while (true)
    {
        Console.Write("Would you like to remove an item? (Y/N): ");
        string answer = Console.ReadLine()?.Trim().ToUpperInvariant();
        if (answer == "N")
        {
            Console.WriteLine("Removal cancelled.");
            return;
        }
        if (answer != "Y")
        {
            Console.WriteLine("Please enter 'Y' or 'N'.");
            continue;
        }

        Console.Write("Enter item number to remove (or 0 to cancel): ");
        if (!int.TryParse(Console.ReadLine(), out int rmvInput) || rmvInput < 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number.");
            continue;
        }
        if (rmvInput == 0)
        {
            Console.WriteLine("Removal cancelled.");
            return;
        }

        int index = rmvInput - 1; // convert to 0-based
        if (index < 0 || index >= CartItems.Count)
        {
            Console.WriteLine($"Please enter a number between 1 and {CartItems.Count}.");
            continue;
        }

        string name = CartItems[index];
        float price = CartPrices[index];
        int currentQty = CartQty[index];

        Console.WriteLine($"Selected: {name} x{currentQty} @ {price:0.00} each.");
        Console.Write("How many would you like to remove? (enter 0 to cancel): ");
        if (!int.TryParse(Console.ReadLine(), out int rmvqty) || rmvqty < 0)
        {
            Console.WriteLine("Invalid quantity. Try again.");
            continue;
        }
        if (rmvqty == 0)
        {
            Console.WriteLine("Removal cancelled.");
            return;
        }

        if (rmvqty >= currentQty)
        {
            // remove entire line
            CartItems.RemoveAt(index);
            CartPrices.RemoveAt(index);
            CartQty.RemoveAt(index);
            Console.WriteLine($"Removed {currentQty} x {name} (line removed).");
        }
        else
        {
            // partial removal: decrement quantity
            CartQty[index] = currentQty - rmvqty;
            Console.WriteLine($"Removed {rmvqty} from {name}. Remaining: {CartQty[index]}");
        }

        return;
    }
}
             */
        }
        /*
       static void RemoveItem()
        {
            // show menu once up-front
            ViewCart();

            // validate Y/N answer (no recursion)
            while (true)
            {
                Console.Write("Would you like to Remove an Item? (Y/N): ");
                string orderBOOL = Console.ReadLine()?.Trim().ToUpperInvariant();

                if (orderBOOL == "Y")
                {
                    // print cart
                    ViewCart();

                    // ask for item number w/ validation)
                    while (true)
                    {
                        Console.Write("What would you like to remove?? (input item number, or 0 to cancel): ");
                        string rmvInputStr = Console.ReadLine();
                        if (!int.TryParse(rmvInputStr, out int rmvInput))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            continue;
                        }

                        if (rmvInput == 0)
                        {
                            Console.WriteLine("Removal cancelled.");
                            break;
                        }

                        if (rmvInput < 0)
                        {
                            Console.WriteLine("Enter a positive number.");
                            continue;
                        }

                        //gather the actual item from the number input
                        Console.WriteLine($"You selected item #{rmvInput}. {CartItems[rmvInput - 1]}.");
                        

                        //Qty and price 
                        Console.Write("How many?: ");
                        string rmvqtyStr = Console.ReadLine();
                        int.TryParse(rmvqtyStr, out int rmvqty);
                        
                        float QTYprice = CartPrices[rmvInput - 1] * rmvqty;
                        float RoundQTYprice = (float)Math.Round(QTYprice);
                        //print current removal selection
                        //Console.WriteLine($"current removal: {CartItems[rmvInput - 1]} for ${CartPrices[rmvInput]:0.00} each x{rmvqty} for a total of ${RoundQTYprice:0.00}");

                        
                       
                        //the whole removing qty mess 
                        int currentQty = CartQty[rmvInput - 1];
                        if (rmvqty >= currentQty)
                        {
                            // remove entire line
                            string removedName = CartItems[rmvInput - 1];
                            int removedQty = CartQty[rmvInput - 1];
                            CartItems.RemoveAt(rmvInput - 1);
                            CartPrices.RemoveAt(rmvInput - 1);
                            CartQty.RemoveAt(rmvInput - 1);
                            Console.WriteLine($"Removed {removedQty} x {removedName} (line removed).");
                        }
                        else
                        {
                            // partial removal: decrement quantity
                            CartQty[rmvInput - 1] = currentQty - rmvqty;
                            Console.WriteLine($"Removed {rmvqty} from {CartItems[rmvInput - 1]}. Remaining: {CartQty[currentQty]}");
                        }
                        CartItems.RemoveAt(rmvInput - 1);
                        CartPrices.RemoveAt(rmvInput - 1);

                        break;
                    }
                    //actually exit this time, pinhead
                    break;
                }
                else if (orderBOOL == "N")
                {
                    Console.WriteLine("No order placed.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter 'Y' or 'N'.");
                }
         */
    }
}
