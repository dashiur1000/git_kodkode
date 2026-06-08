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
    cursor.execute("DESCRIBE soldiers")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return [{"column": row[0], "type": row[1]} for row in rows]


def create(name: str, ranki: str, unit: str, active: bool):
    conn = get_connection()
    cursor = conn.cursor()

    sql = "INSERT INTO soldiers (name, `rank`, unit, active) VALUES (%s, %s, %s, %s)"
    values = (name, ranki, unit, active)

    cursor.execute(sql, values)
    conn.commit()

    new_id = cursor.lastrowid

    cursor.close()
    conn.close()
    return new_id


def update(soldier_id: int, data: dict) -> bool:
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    set_parts = [f"{key} = %s" for key in data.keys()]
    set_clause = ", ".join(set_parts)

    sql = f"UPDATE soldiers SET {set_clause} WHERE id = %s"
    values = list(data.values()) + [soldier_id]

    cursor.execute(sql, values)
    conn.commit()

    changed = cursor.rowcount > 0

    cursor.close()
    conn.close()
    return changed





