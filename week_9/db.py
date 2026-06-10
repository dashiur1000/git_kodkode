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




def delete(soldier_id: int) -> bool:
    conn = get_connection()
    cursor = conn.cursor()
    cursor.execute("DELETE FROM soldiers WHERE id = %s", (soldier_id,))
    conn.commit()
    deleted = cursor.rowcount > 0
    cursor.close()
    conn.close()
    return deleted



def get_all() -> list:
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)   # returns dicts instead of tuples
    cursor.execute("SELECT * FROM soldiers")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return rows

def get_by_id(soldier_id: int) -> dict | None:
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)
    cursor.execute("SELECT * FROM soldiers WHERE id = %s", (soldier_id,))
    row = cursor.fetchone()   # returns one dict or None
    cursor.close()
    conn.close()
    return row


def get_names_and_ranks() -> list:
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)
    cursor.execute("SELECT id, name, `rank` FROM soldiers")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return rows


def get_by_rank(rank: str) -> list:
    print(f"DEBUG: Getting soldiers with rank: '{rank}'")
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)
    cursor.execute(
    "SELECT * FROM soldiers WHERE rank = %s",(rank,)
    )
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return rows


def search_by_name(term: str) -> list:
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)
    cursor.execute(
    "SELECT * FROM soldiers WHERE name LIKE %s",
    (f"%{term}%",)
    )
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return rows



def get_active_sorted(order: str = "asc") -> list:
    if order.lower() not in ("asc", "desc"):
        order = "asc"
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)
    cursor.execute(
        f"SELECT * FROM soldiers WHERE active = TRUE ORDER BY name {order.upper()}"
    )
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return rows


def get_distinct_units() -> list:
    conn = get_connection()
    cursor = conn.cursor()
    cursor.execute("SELECT DISTINCT unit FROM soldiers")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return [row[0] for row in rows]


def get_with_missing_rank() -> list:
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)
    cursor.execute("SELECT * FROM soldiers WHERE `rank` IS NULL")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return rows


# def count_by_unit() -> list:
#     conn = get_connection()
#     cursor = conn.cursor(dictionary=True)
#     cursor.execute("""
#     SELECT unit,
#     COUNT(*) AS total
#     FROM soldiers
#     GROUP BY unit
#     ORDER BY total DESC
#     """)
#     rows = cursor.fetchall()
#     cursor.close()
#     conn.close()
#     return rows





def get_summary() -> dict:
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    cursor.execute("SELECT COUNT(*) AS total FROM soldiers")
    total = cursor.fetchone()["total"]

    cursor.execute("SELECT COUNT(*) AS active FROM soldiers WHERE active = TRUE")
    active = cursor.fetchone()["active"]\

    conn.close()
    cursor.close()

    return {"total": total, "active": active, "inactive": total-active}




def count_by_unit() -> list:
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    cursor.execute("""
    SELECT unit,
    COUNT(*) AS total
    FROM soldiers
    GROUP BY unit
    ORDER BY total DESC
    """)


    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return rows

def get_units_with_multiple_soldiers():
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)
    cursor.execute("""
    SELECT `unit`, count(`unit`) as counter FROM soldiers group by `unit` having counter > 1; 
    """)
    row = cursor.fetchall()
    conn.close()
    cursor.close()
    return row


def get_max_unit():
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)
    cursor.execute("""
    SELECT `unit`, count(*) as max FROM soldiers group by `unit` order by max DESC""")
    row = cursor.fetchall()
    conn.close()
    cursor.close()
    return row