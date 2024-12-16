import { Modal } from "antd";
import { ItemRequest } from "../services/Items";
import Input from "antd/es/input/Input";
import { SetStateAction, useEffect, useState } from "react";
import TextArea from "antd/es/input/TextArea";

interface Props {
  mode: Mode;
  values: Item;
  isModalOpen: boolean;
  handleCancel: () => void;
  handleCreate: (request: ItemRequest) => void;
  handleUpdate: (id: string, request: ItemRequest) => void;
}
export enum Mode {
  Create,
  Edit,
}

export const CreateUpdateItem = ({
  mode,
  values,
  isModalOpen,
  handleCancel,
  handleCreate,
  handleUpdate,
}: Props) => {
  const [title, setTitle] = useState<string>("");
  const [description, setDescription] = useState<string>("");
  const [price, setPrice] = useState<number>(1);

  useEffect(() => {
    setTitle(values.title);
    setDescription(values.description);
    setPrice(values.price);
  }, [values]);

  const handleOnOk = async () => {
    const itemRequest = { title, description, price };

    mode === Mode.Create
      ? handleCreate(itemRequest)
      : handleUpdate(values.id, itemRequest);
  };

  return (
    <Modal
      title={mode === Mode.Create ? "add" : "edit"}
      open={isModalOpen}
      onOk={handleOnOk}
      onCancel={handleCancel}
      cancelText={"cancel"}
    >
      <div className="item__modal">
        <Input
          value={title}
          onChange={(event: { target: { value: SetStateAction<string>; }; }) => setTitle(event.target.value)}
          placeholder="title..."
        />
        <TextArea
          value={description}
          onChange={(e: { target: { value: SetStateAction<string>; }; }) => setDescription(e.target.value)}
          placeholder="description..."
        />
        <Input
          value={price}
          onChange={(e: { target: { value: SetStateAction<number>; }; }) => setPrice(e.target.value)}
          placeholder="price..."
        />
      </div>
    </Modal>
  );
};
