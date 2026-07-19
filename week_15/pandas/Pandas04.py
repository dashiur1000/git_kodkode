import pandas as pd
data = {
    "price_usd": ["150", "200", "150", "350"],

    "price_nis": ["400", "600", "400", "1050"],

    "random_garbage_column": ["xyz", "abc", "xyz", "qwe"]
}
df = pd.DataFrame(data)
df["price_usd"] = df["price_usd"].astype(int)
df["price_nis"] = df["price_nis"].astype(int)
dd = df["price_usd"].mean()
ss = df["price_usd"].std()
print(dd)
print(ss)