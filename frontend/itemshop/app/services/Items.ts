
export interface ItemRequest {
    title: string,
    description: string,
    price: number
}

export const getAllItems = async () => {
    const response = await fetch("http://localhost:5011/Items");

    return response.json()
}

export const createItem = async (itemRequest: ItemRequest) => {
    await fetch("http://localhost:5011/Items", {
        method: "POST", headers: {
            "content-type": "application/json"
        },
        body: JSON.stringify(itemRequest)
    })
}

export const updateItem = async (id: string, itemRequest: ItemRequest) => {
    await fetch(`http://localhost:5011/Items/${id}`, {
        method: "PUT", headers: {
            "content-type": "application/json"
        },
        body: JSON.stringify(itemRequest)
    })
}

export const deleteItem = async (id: string) => {
    await fetch(`http://localhost:5011/Items/${id}`, {
        method: "DELETE"
    })
}