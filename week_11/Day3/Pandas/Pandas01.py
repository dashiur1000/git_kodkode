import pandas as pd

df = pd.read_csv("tracks.csv")
# df.head() # return all table
# df.head(3) # return 3 lines
# df.info() # print all table and info
# print(df.describe())
print(df.shape)