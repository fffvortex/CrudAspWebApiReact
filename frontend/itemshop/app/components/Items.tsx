import Card from "antd/es/card/Card";
import { CardTitle } from "./Cardtitle";
import { Button } from "antd";

interface Props {
  items: Item[];
  handleDelete: (id: string) => void;
  handleOpen: (item: Item) => void;
}

export const Items = ({ items,handleDelete,handleOpen }: Props) => {
  return (
    <div className="cards">
      {items.map((item: Item) => (
        <Card style={{border:"solid 1px darkblue", margin: "5px"}}
          key={item.id}
          title={<CardTitle title={item.title} price={item.price}></CardTitle>}
          bordered={false}
        >
          <p>{item.description}</p>
          <div className="card__buttons">
            <Button onClick={()=> handleOpen(item)} style={{flex: 1, marginInline:"10px"}} >edit</Button>
            <Button onClick={()=> handleDelete(item.id)} style={{flex: 1}} danger >delete</Button>
          </div>
        </Card>
      ))}
    </div>
  );
};
