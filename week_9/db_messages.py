import mysql.connector

def get_connection():
    return mysql.connector.connect(
        host="localhost",
        port=3306,
        user="root",
        password="root",
        database="soldiers_db")



def get_schema() -> list:
    conn = get_connection()
    cursor = conn.cursor()
    cursor.execute("DESCRIBE messages")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return [{"column": row[0], "type": row[1]} for row in rows]


def get_all_messages():
    conn = get_connection()
    cursor = conn.cursor()
    cursor.execute("SELECT * FROM messages")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return rows

