import logging
# 1
logging.basicConfig(level=logging.DEBUG, format="%(asctime)s | %(levelname)s | %(message)s")
logger = logging.getLogger("bibist")
# def before_function():
#     logger.info("logger before function")
#
# def after_function():
#     logger.info("logger after function")
#
# def add(a, b):
#     before_function()
#     result = a + b
#     after_function()
#     return result
#
# # 2
# def logger_with_user_id(user_id):
#     logger.info("user id: %s", user_id)
#
#
# # 3
# def process_payment(username, amount):
#     logger.info("Starting payment process...")
#
#     if amount <= 0:
#         logger.error("Error: Amount must be greater than zero!")
#         return False
#
#     logger.info("Charging %s", username, "the amount of %s", amount, "dollars.")
#
#     logger.info("Payment processed successfully.")
#     return True
#
# # 4
# def divide(a, b):
#     if b != 0:
#         return a / b
#     else:
#         logger.error("divide can not by %s", b)

# 5
# DEBUG:
# INFO: משתמש התחבר בהצלחה למערכת, ההזמנה נשלחה בהצלחה
# WARNING

# 6

# 1
# לא נכון
# נכון
# לא נכון
# לא נכון
# נכון
# נכון
# לא נכון

# 2
# INFO
# ERROR
# DEBUG
# ERROR
# WARNING
# INFO

# 3
logger.error('User logged in successfully')
logger.info('User logged in successfully')

#logger.info('Login', email, password)
# לא מכניסים דברים כאלו

print('ERROR: payment failed')
payment_failed = "dd"
print('ERROR %s', payment_failed)

# 4
# %(asctime)s: הזמן בו הלוג אירע
# %(levelname)s: סוג הלוג (דיבאג, שגיאה וכו')
# %(name)s: מי גרם ללוג לקרות
# %(message)s: מה ההודעה שהלוג שולח

# 5
import logging
logging.basicConfig(level=logging.INFO, format='%(levelname)s | %(message)s')
logger = logging.getLogger(__name__)
logger.info('Application started')

# 6
def process_payment(user_id, amount):
    logger.info('Starting payment for user %s', user_id)
    if amount <= 0:
        logger.error('Invalid %s', amount)
        return
    if amount > 10000:
        logger.warning('Large transaction')
    logger.info('Payment of completed for user %s', amount, user_id)

# 7
logger = logging.getLogger("payments")
logger.setLevel(logging.DEBUG)

file_handler = logging.FileHandler("app.log", encoding="utf-8")
formatter = logging.Formatter("%(asctime)s | %(levelname)s | %(name)s")
file_handler.setFormatter(formatter)
logger.addHandler(file_handler)

def func_for_logs(name):
    logger.info("open the file %s", name)
    logger.error("error the file %s", name)
    logger.warning("warning the file %s", name)
func_for_logs("dudi")

# 8
def read_config(filepath):
    logger.debug("Interested in opening %s", filepath)
    try:
        with open(filepath) as f:
            data = f.read()
        logger.info("managed to open %s", filepath)
        return data
    except FileNotFoundError:
        logger.exception("An error occurred in %s", filepath)
        return None

# 10
# logger.info('done')
# logger.info('Payment process completed for user%s', file_handler)
#
# logger.error('failed')
# logger.error('Failed to process payment: %s', name)
#
# logger.info('user=%s', user_id)
# logger.info('user id is=%s', user_id, "is true")


# 11
# info
# error
# debug
# warning
# info
# error

# 12
import logging
logging.basicConfig(level=logging.DEBUG, format="%(asctime)s | %(levelname)s | %(message)s")
logger = logging.getLogger(__name__)
def register_user(email, password, age):
    logger.debug("check the %s %s", email, age)
    if age < 18:
        logger.error("error! the age %s is too young", age)
        return
    logger.info("the email %s is true", email)
    logger.info("the mission is accomplished")