from uuid import main

from fastapi import FastAPI, HTTPException, Query
import db
import uvicorn
from pydantic import BaseModel

app = FastAPI()

class SoldierIn(BaseModel):
    name: str
    rank: str | None = None
    unit: str | None = None
    active: bool = True

@app.post("/setup")
def run_setup():
    return {"status": "setup triggered"}

@app.get("/schema")
def get_schema():
    columns = db.get_schema()
    return {"columns": columns}

@app.get("/soldiers")
def list_soldiers(
        rank: str | None = Query(default=None),
        sort: str = Query(default=None)
):
    if rank:
        return {"soldiers": db.get_by_rank(rank)}
    elif sort:
        return {"soldiers": db.get_active_sorted(sort)}
    return {"soldiers": db.get_all()}



@app.post("/soldiers", status_code=201)
def add_soldier(body: SoldierIn):
    new_id = db.create(body.name, body.rank, body.unit, body.active)
    if not new_id:
        raise HTTPException(status_code=404, detail="Soldier not found")
    return {"id": new_id, "message": "Soldier created"}


@app.get("/soldiers/units")
def list_units():
    return {"units": db.get_distinct_units()}


@app.get("/soldiers/search")
def search_soldiers(name: str = Query(...)):
    return {"soldiers": db.search_by_name(name)}

@app.get("/soldiers/missing-rank", status_code=200)
def get_missing_rank():
    return {"missing": db.get_with_missing_rank()}

@app.get("/stats/summary")
def stats_summary():
    return db.get_summary()


@app.get("/stats/units")
def stats_by_unit():
    return {"by_unit": db.count_by_unit()}

@app.get("/stats/understaffed")
def get_unit_more_from_one():
    return db.get_units_with_multiple_soldiers()


@app.get("/stats/units/top")
def get_max_unit():
    return db.get_max_unit()




@app.put("/soldiers/{soldier_id}")
def edit_soldier(soldier_id: int, body: SoldierIn):
    data = body.model_dump(exclude_none=True)
    success = db.update(soldier_id, data)
    if not success:
        raise HTTPException(status_code=404, detail="Soldier not found")
    return {"message": "Updated"}

@app.delete("/soldiers/{soldier_id}")
def remove_soldier(soldier_id: int):
    success = db.delete(soldier_id)
    if not success:
        raise HTTPException(status_code=404, detail="Soldier not found")
    return {"message": "Deleted"}

@app.get("/soldiers/{soldier_id}")
def get_soldier(soldier_id: int):
    soldier = db.get_by_id(soldier_id)
    if soldier is None:
        raise HTTPException(status_code=404, detail="Soldier not found")
    return soldier


if __name__ == "__main__":
    uvicorn.run("main:app", port=8005, reload=True)