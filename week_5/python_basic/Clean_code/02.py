def check_user_email(email):
    if not email:
        print("Invalid user")
        return None
    else:
        return email

def check_quantity(quantity, stock):
    stock -= quantity
    if quantity <= 0 or quantity > stock:
        print("Invalid quantity")
        return False
    else:
        return quantity

def check_all_price(product_price, quantity):
    price = product_price * quantity
    if quantity >= 10:
        price *= 0.9
    if quantity >= 50:
        price *= 0.85
    return price

def print_order(status, user, quantity, product, total):
    print(f"Order {status}: {user} bought {quantity}x {product} for ${total}")


def handle_purchase(user_email, product_name, product_price, stock, quantity):
    order_user = check_user_email(user_email)
    order_product = product_name
    order_quantity = check_quantity(quantity, stock)
    if order_user == None or order_quantity == False:
        return False
    order_total = check_all_price(product_price, quantity)
    order_status = "confirmed"
    print_order(order_status, order_user, order_quantity, order_product, order_total)
    return order_user, order_product, order_quantity, order_total, order_status

my_store = handle_purchase("dzs101010@gmail.com", "banana", 10, 105, 10)