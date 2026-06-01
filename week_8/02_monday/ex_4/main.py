import requests

response = requests.get("https://jsonplaceholder.typicode.com/posts")
posts = response.json()

response2 = requests.get("https://jsonplaceholder.typicode.com/users")
users = response2.json()

new_dict = {}

for user in users:
    new_dict[user["id"]] = user["name"]

for post in posts:
    new_post = post["userId"]
    author_name = new_dict[new_post]
    print(f"{post["title"]} by {author_name}")




response3 = requests.get("https://jsonplaceholder.typicode.com/posts")