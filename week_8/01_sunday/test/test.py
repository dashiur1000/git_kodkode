from fastapi import FastAPI

app = FastAPI()


@app.get("/item/{item_id}")
def get_item(item_id: int):
    return {"item_id": item_id}

@app.get("/items/count")
def count_items():
    return {"count": 0}
