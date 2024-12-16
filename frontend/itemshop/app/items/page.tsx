"use client";

import { Button } from "antd";
import { Items } from "../components/Items";
import { useEffect, useState } from "react";
import {
  createItem,
  deleteItem,
  getAllItems,
  ItemRequest,
  updateItem,
} from "../services/Items";
import Title from "antd/es/skeleton/Title";
import { CreateUpdateItem, Mode } from "../components/CreateUpdateItem";

export default function ItemsPage() {
    const defaultValues ={
        title: "",
        description: "",
        price: 1,
      } as Item
  const [values, setValues] = useState<Item>(defaultValues);

  const [items, setItems] = useState<Item[]>([]);
  const [loading, setLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [mode, setMode] = useState(Mode.Create);

  useEffect(() => {
    const getItems = async () => {
      const items = await getAllItems();
      setLoading(false);
      setItems(items);
    };

    getItems();
  }, []);

  const handleCreateItem = async (request: ItemRequest) => {
    await createItem(request);
    closeModal();

    const items = await getAllItems();
    setItems(items);
  };

  const handleUpdateItem = async (id: string, request: ItemRequest) => {
    await updateItem(id, request);
    closeModal();

    const items = await getAllItems();
    setItems(items);
  };

  const handleDeleteItem = async (id: string) => {
    await deleteItem(id);
    closeModal();

    const items = await getAllItems();
    setItems(items);
  };

  const openModal = () => {
    setMode(Mode.Create);
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setValues(defaultValues)
    setIsModalOpen(false);
  };

  const openEditModal = (item: Item) => {
    setMode(Mode.Edit);
    setValues(item);
    setIsModalOpen(true);
  };

  return (
    <div style={{textAlign: "center"}} >
      <h1 style={{marginInline: "auto"}}>items</h1>
      <Button type="primary" style={{marginTop: "30px"}} onClick={openModal} >add</Button>
      <CreateUpdateItem
        mode={mode}
        values={values}
        isModalOpen={isModalOpen}
        handleCreate={handleCreateItem}
        handleUpdate={handleUpdateItem}
        handleCancel={closeModal}
      />

      {loading ? <Title>Loading...</Title> : <Items items={items} handleDelete={handleDeleteItem} handleOpen={openEditModal} ></Items>}
    </div>
  );
}
