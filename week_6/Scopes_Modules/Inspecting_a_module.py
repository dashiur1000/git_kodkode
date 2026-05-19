def public_names(mdl):
    list_for_mdl = []
    for i in dir(mdl):
        if not i.startswith("__"):
            list_for_mdl.append(i)
    return list_for_mdl

print(public_names("datetime"))