import mysql.connector

my_sql = mysql.connector.connect(
    host="localhost",
    user="yourusername",
    password="yourpassword"
)

conn = my_sql.cursor()
conn.execute("SHOW ")
