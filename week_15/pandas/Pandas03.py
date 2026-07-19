import pandas as pd

data = {
    "price_usd": ["150", "200", "150", "350"],

    "date_str": ["2026-07-01", "2026-07-02", "2026-07-01", "2026-07-04"],

    "random_garbage_column": ["xyz", "abc", "xyz", "qwe"]
}

df = pd.DataFrame(data)
df = df.drop_duplicates()
df = df.drop(columns=["random_garbage_column"])
df["price_usd"] = df["price_usd"].astype(int)
print(df["price_usd"][0]+df["price_usd"][1])