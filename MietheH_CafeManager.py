#Practice Lab: Cafe order manager
import math


'''

ilist = []
plist = []
qlist = []
'''


# ilist.append("coffee")
# plist.append(2.50)
# qlist.append(3)

def createCart():
    return list()


#defining my variables
cafe_name = "McAnally's"
tax_rate = 0.07
name = ""
#name = list()
price = 0.00
#price = list()
qty = 0
#qty = list()
cart = createCart()
cart_prices = list()
cart_qty = list()
subtotal = 0.00
final_total = 0.00




def ShowFoodMenu():
    return ["Coffee", "Mocha", "Latte", "Donut", "Bagel", "Muffin"]

def FoodPrices():
    return [2.00, 2.50, 3.00, 1.00, 3.00, 1.50]

def FullFoodMenu():
    counter = 0
    for x in range(len(ShowFoodMenu())):
        print(f"{counter}. {ShowFoodMenu()[x]}: ${FoodPrices()[x]}")
        counter += 1

# def PrintReceipt():
#     print("--------------------------------")
#     for n in range((len(cart))):
#         print(f"{n+1}) {cart[n]} x{cart_qty}......... {cart_prices[n]}")
#     print(f"SUBTOTAL: {subtotal}")
#     print("DISCOUNT -- 10% OFF!")
#     print(f"TAX RATE: {tax_rate}")
#     print(f"TOTAL: {final_total}")
#     print("--------------------------------")



def  show_banner():
    print("===============================")
    print(f"{cafe_name} - {tax_rate}")
    print("===============================")



def view_cart(cart, cart_prices, cart_qty):
    print("------cart------")
    for n in range(len(cart)):
        print(f"{n+1}) {cart[n]} x{cart_qty[n]} -- {cart_prices[n]}")
    print("----------------")


def add_item(name, price, qty):
    FullFoodMenu()
    #ask what they want from given menu (menu provides name and price, numbered), then how many. then allows them to exit
    order = input("Would you like to order? (Y/N) ")
    if(order.upper() == "Y"):
        item_input = int(input("What would you like? (by list number) "))
        print(f"you selected {ShowFoodMenu()[item_input]}")
        item_name = ShowFoodMenu()[item_input]
        name = item_name
        #Item price W/O qty
        item_price = FoodPrices()[item_input]
        price  = FoodPrices()[item_input]
        item_qty = int(input("How many of this item? "))
        qty = item_qty
        #items price WITH qty
        items =  price * item_qty
        cart.append(name)
        cart_qty.append(qty)
        cart_prices.append(items)
        view_cart(cart, cart_prices, cart_qty)
    elif(order.upper() == "N"):
        print("Order wrapped up!")
    


def remove_item(cart, cart_prices):
    view_cart(cart, cart_prices, cart_qty)
    try:
        userInput = int(input("Which item do you wish to remove by the number? "))
        if(userInput < 1 or userInput > len(cart)):
            raise ValueError("Invalid Choice!")
        else:
            temp = cart.pop(userInput - 1)
            tempPrice = cart_prices.pop(userInput - 1)
            tempUserInput = input(f"Are you sure you want to remove {temp} priced at {tempPrice}? (Y/N) ")
        if(tempUserInput.upper() == "N"):
            cart.insert(userInput - 1, temp)
        else:
            print("Item removed!")

        view_cart(cart, cart_prices, cart_qty)

    except ValueError:
        print("We can't do that! Try again.")
        remove_item(cart, cart_prices, cart_qty)




def checkout():
    final_total = 0.00
    #recieve discount code, calc subtotal, tax, discount, and final total
    for n in range(len(cart_prices)):
        subtotal = sum(cart_prices)
    print(f"Cart subtotal: {subtotal} ") 

    #discount
    askDiscount = input("Enter Discount Code \" STUDENT10\": ")
    if(askDiscount == "STUDENT10"):
        discount = 0.10
    else:
        print("Nope! not the right code!")
        discount = 0.00
    subtotal -=  subtotal * discount

    #tax
    subtotal += subtotal * tax_rate

    #rounding and final total
    subtotal = round(subtotal, 2)
    final_total = round(subtotal, 2)

    def PrintReceipt():
        print("--------------------------------")
        for n in range((len(cart))):
            print(f"{n+1}) {cart[n]} x{cart_qty}......... {cart_prices[n]}")
        print(f"SUBTOTAL: {subtotal}")
        print("DISCOUNT -- 10% OFF!")
        print(f"TAX RATE: {tax_rate}")
        print(f"TOTAL: {final_total}")
        print("--------------------------------")

    PrintReceipt()




def exit():
    print(f"thak you for eating at {cafe_name}!! Come again!")

    

def main_menu():


    print("========================")
    print("1. View Cart")
    print("2. Add Item")
    print("3. Remove Item")
    print("4. Checkout")
    print("5. Exit")
    print("=========================")
    try:
        userChoice = int(input("Please select which option you wish to do! "))
        if(userChoice < 1 or userChoice > 5):
            raise ValueError("Invalid reponse! Try again!")
        return userChoice
    except ValueError:
        print("Invalid reponse! Try again!")
        main_menu()

    


def main():
    #cart is global
   

    print(f"Welcome to {cafe_name}!!")
    #present banner at top
    #show_banner()

    #user options
    userMenuChoice = main_menu()
    while(userMenuChoice != 5):
        if(userMenuChoice == 1):  #fix view_cart !!!!!
            view_cart(cart, cart_prices, cart_qty)
            userMenuChoice = main_menu()
        elif(userMenuChoice == 2):    
            add_item(name, price, qty)
            userMenuChoice = main_menu()

        elif(userMenuChoice == 3):
            remove_item(cart, cart_prices)
            userMenuChoice = main_menu()

        elif(userMenuChoice == 4):
            checkout()
            userMenuChoice = main_menu()
    exit()




main()