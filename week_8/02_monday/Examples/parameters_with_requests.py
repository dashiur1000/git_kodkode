import requests

params = {"userId": 1}
response = requests.get("https://jsonplaceholder.typicode.com/posts", params=params)

posts = response.json()
print(f"Found {len(posts)} posts for user 1")
for post in posts[:1]:
    print(f"{post['title']}")